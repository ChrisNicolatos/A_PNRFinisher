Public Class frm02Finisher

    Private mSelectedGDSCode As EnumGDSCode
    Private mSelectedBOCode As EnumBOCode

    Private mflgLoading As Boolean
    Private mflgReadPNR As Boolean

    Private mobjPNR As GDSReadPNR

    Private mobjCustomerSelected As CustomerItem
    Private mobjSubDepartmentSelected As SubDepartmentItem
    Private mobjCRMSelected As CRMItem
    Private mobjVesselSelected As VesselItem
    Private mobjAirlinePoints As New AirlinePointsCollection

    Private mflgAPISUpdate As Boolean
    Private mflgExpiryDateOK As Boolean

    Private mfrmItinHelper As frmItineraryHelper
    Private mfrmCTC As New frmPaxCTC
    Private mfrmCTCPax As New frmPaxCTCOnlyPax
    Private mobjCTC As New CTCPaxCollection

    Private mobjGender As New ReferenceGenderCollection

    Private Sub cmdPNRRead1APNR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPNRRead1APNR.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Amadeus
            mobjPNR = New GDSReadPNR(mSelectedGDSCode)
            PNRReadPNR()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdPNRRead1GPNR_Click(sender As Object, e As EventArgs) Handles cmdPNRRead1GPNR.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Galileo
            mobjPNR = New GDSReadPNR(mSelectedGDSCode)
            PNRReadPNR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdCostCentre_Click(sender As Object, e As EventArgs) Handles cmdCostCentre.Click

        Try
            Dim pfrmcostCentre As New frmCostCentre(MySettings.PCCBackOffice)
            Dim pResult As System.Windows.Forms.DialogResult
            mflgLoading = False
            pResult = pfrmcostCentre.ShowDialog()

            If pResult = Windows.Forms.DialogResult.OK Then
                txtCustomer.Text = pfrmcostCentre.CodeSelected
                txtVessel.Text = pfrmcostCentre.VesselSelected
                DisplayOldCustomProperty(cmbCostCentre, pfrmcostCentre.CostCentreSelected)
            End If
            pfrmcostCentre.Close()
        Catch ex As Exception
            MessageBox.Show("cmdCostCentre_Click()" & vbCrLf & ex.Message)
        End Try


    End Sub

    Private Sub cmdOneTimeVessel_Click(sender As Object, e As EventArgs) Handles cmdOneTimeVessel.Click

        Try
            Dim pFrm As New frmVesselForPNR

            If pFrm.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetVesselForPNR("", "")
                    mobjPNR.NewElements.VesselName.SetText(pFrm.VesselName & If(pFrm.Registration <> "", " REG " & pFrm.Registration, ""))
                    mflgLoading = True
                    txtVessel.Text = pFrm.VesselName & If(pFrm.Registration <> "", " REG " & pFrm.Registration, "")
                    'PopulateVesselsList()
                End If
                'With mobjPNR.NewElements
                '    .SetVesselForPNR(pFrm.VesselName, pFrm.Registration)
                '    mflgLoading = True
                '    txtVessel.Text = .VesselNameForPNR.TextRequested & If(.VesselFlagForPNR.TextRequested <> "", " REG " & .VesselFlagForPNR.TextRequested, "")
                'End With
            End If
            pFrm.Dispose()
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub
    Private Sub cmdPNRWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPNRWrite.Click

        Try
            PNRWrite(True, False)
            ShowPriceOptimiser(Me.MdiParent, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdPNRWriteWithDocs_Click(sender As Object, e As EventArgs) Handles cmdPNRWriteWithDocs.Click
        Try
            PNRWrite(True, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdPNROnlyDocs_Click(sender As Object, e As EventArgs) Handles cmdPNROnlyDocs.Click
        Try
            PNRWrite(False, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    PopulateCustomerList(txtCustomer.Text)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub txtSubdepartment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubdepartment.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    PopulateSubdepartmentsList(txtSubdepartment.Text)
                End If
            End If

            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub txtCRM_TextChanged(sender As Object, e As EventArgs) Handles txtCRM.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    PopulateCRMList(txtCRM.Text)
                End If
            End If

            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub lstCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCustomers.SelectedIndexChanged

        Try
            If lstCustomers.SelectedIndex >= 0 Then
                mflgLoading = True
                Dim pCust As CustomerItem = CType(lstCustomers.SelectedItem, CustomerItem)
                SelectCustomer(pCust)
                txtCustomer.Text = lstCustomers.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub lstSubDepartments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSubDepartments.SelectedIndexChanged

        Try
            If Not lstSubDepartments.SelectedItem Is Nothing Then
                mflgLoading = True
                Dim pSubDepartmentItem As SubDepartmentItem
                pSubDepartmentItem = CType(lstSubDepartments.SelectedItem, SubDepartmentItem)
                SelectSubDepartment(pSubDepartmentItem)
                txtSubdepartment.Text = lstSubDepartments.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub lstCRM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCRM.SelectedIndexChanged

        Try
            If Not lstCRM.SelectedItem Is Nothing Then
                mflgLoading = True
                Dim pCRMItem As CRMItem
                pCRMItem = CType(lstCRM.SelectedItem, CRMItem)
                SelectCRM(pCRMItem)
                txtCRM.Text = lstCRM.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub txtVessel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVessel.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetVesselForPNR("", "")
                    mobjPNR.NewElements.VesselName.SetText(txtVessel.Text)
                    PopulateVesselsList()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lstVessels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVessels.SelectedIndexChanged

        Try
            If lstVessels.SelectedIndex >= 0 Then
                mflgLoading = True
                Dim pVesselItem As VesselItem = CType(lstVessels.SelectedItem, VesselItem)
                SelectVessel(pVesselItem)
                txtVessel.Text = lstVessels.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub cmbBookedby_TextChanged(sender As Object, e As EventArgs) Handles cmbBookedby.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetBookedBy(cmbBookedby.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbReasonForTravel_TextChanged(sender As Object, e As EventArgs) Handles cmbReasonForTravel.TextChanged, cmbReasonForTravel.SelectedIndexChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetReasonForTravel(cmbReasonForTravel.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbCostCentre_TextChanged(sender As Object, e As EventArgs) Handles cmbCostCentre.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetCostCentre(cmbCostCentre.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub txtTrId_TextChanged(sender As Object, e As EventArgs) Handles txtTrId.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetTRId(txtTrId.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtReference_TextChanged(sender As Object, e As EventArgs) Handles txtReference.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetReference(txtReference.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbDepartment_TextChanged(sender As Object, e As EventArgs) Handles cmbDepartment.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetDepartment(cmbDepartment.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub APISDisplayPax()
        If mobjPNR.SSRDocsExists Then
            txtPNRApis.Location = dgvApis.Location
            txtPNRApis.Size = dgvApis.Size
            txtPNRApis.Text = mobjPNR.SSRDocs
            txtPNRApis.BackColor = Color.Aqua
            txtPNRApis.ForeColor = Color.Blue
            txtPNRApis.Visible = True
            txtPNRApis.BringToFront()
            cmdAPISEditPax.Enabled = False
        Else
            txtPNRApis.Visible = False
            Dim pobjPaxApis As New ApisPaxCollection
            dgvApis.Rows.Clear()
            For Each pobjPax As GDSPaxItem In mobjPNR.Passengers.Values
                Dim pobjPaxItem As New ApisPaxItem(pobjPax.LastName, pobjPax.Initial)
                pobjPaxApis.Read(pobjPax.LastName, APISModifyFirstName(pobjPax.Initial))
                If pobjPaxApis.Count = 0 Then
                    APISAddRow(dgvApis, pobjPax.ElementNo, pobjPax.LastName, pobjPax.Initial, "", "", "", Date.MinValue, "", Date.MinValue)
                Else
                    If pobjPaxApis.Count > 1 Then
                        Dim pFrm As New frmAPISPaxSelect(pobjPax.ElementNo, pobjPax.LastName, pobjPax.Initial, pobjPaxApis)
                        If pFrm.ShowDialog(Me) = DialogResult.OK Then
                            pobjPaxItem = pFrm.SelectedPassenger
                        End If
                    Else
                        pobjPaxItem = pobjPaxApis.Values(0)
                    End If
                    APISAddRow(dgvApis, pobjPax.ElementNo, pobjPax.LastName, pobjPax.Initial, pobjPaxItem.IssuingCountry, pobjPaxItem.PassportNumber, pobjPaxItem.Nationality, pobjPaxItem.BirthDate, pobjPaxItem.Gender, pobjPaxItem.ExpiryDate)
                End If
                APISValidateDataRow(dgvApis.Rows(dgvApis.RowCount - 1))
            Next
            cmdAPISEditPax.Enabled = True
        End If
    End Sub
    Public Sub APISValidateDataRow(ByVal Row As DataGridViewRow)
        Dim pdteDate As DateTime
        Dim pflgGenderFound As Boolean = False
        Dim pflgBirthDateOK As Boolean = False
        Dim pflgPassportNumberOK As Boolean = False
        Dim pstrErrorText As String = ""

        pflgPassportNumberOK = (CStr(Row.Cells("PassportNumber").Value).Trim.Length > 0)
        If Not Date.TryParse(Row.Cells("Birthdate").Value.ToString, pdteDate) Then
            pdteDate = DateFromIATA(Row.Cells("Birthdate").Value.ToString)
            If pdteDate > Date.MinValue Then
                pflgBirthDateOK = True
            Else
                pflgBirthDateOK = False
            End If
        Else
            pflgBirthDateOK = True
        End If
        If Not Date.TryParse(CStr(Row.Cells("ExpiryDate").Value), pdteDate) Then
            pdteDate = DateFromIATA(CStr(Row.Cells("ExpiryDate").Value))
        End If
        If pdteDate > Now Then
            mflgExpiryDateOK = True
        Else
            mflgExpiryDateOK = False
        End If
        pflgGenderFound = False
        For Each pGenderItem As ReferenceItem In mobjGender.Values
            If CStr(Row.Cells("Gender").Value) = pGenderItem.Code Then
                pflgGenderFound = True
                Exit For
            End If
        Next
        mflgAPISUpdate = mflgAPISUpdate Or (Not mobjPNR.SSRDocsExists And mobjPNR.SegmentsExist And pflgBirthDateOK And pflgGenderFound) '  And pflgPassportNumberOK)
        If Not pflgBirthDateOK Then
            pstrErrorText &= "Invalid birth date" & vbCrLf
        End If
        If Not pflgGenderFound Then
            pstrErrorText &= "Invalid gender" & vbCrLf
        End If
        If Not pflgPassportNumberOK Then
            pstrErrorText &= "Passport number missing" & vbCrLf
        End If
        If Not mflgExpiryDateOK Then
            pstrErrorText &= "Invalid expiry date" & vbCrLf
        End If
        If mobjPNR.SSRDocsExists Then
            lblSSRDocs.Text = "SSR DOCS already exist in the PNR"
            lblSSRDocs.BackColor = Color.Red
            cmdAPISEditPax.Enabled = False
        Else
            If mobjPNR.SegmentsExist Then
                lblSSRDocs.Text = "SSR DOCS"
                lblSSRDocs.BackColor = Color.Yellow
                cmdAPISEditPax.Enabled = True
            Else
                lblSSRDocs.Text = "SSR DOCS cannot be updated - No segments in PNR"
                lblSSRDocs.BackColor = Color.Red
                cmdAPISEditPax.Enabled = False
            End If
        End If
        Row.ErrorText = pstrErrorText
        SetEnabled()

    End Sub

    Private Sub PopulateCRMList(ByVal SearchString As String)

        Try
            Dim pobjCRM As New CRMCollection

            If SearchString = "" Then
                mobjCRMSelected = Nothing
                mobjPNR.NewElements.SetCRM(0, "", "")
            End If
            lstCRM.Items.Clear()

            If Not mobjCustomerSelected Is Nothing Then
                pobjCRM.Load(mobjCustomerSelected.ID, MySettings.PCCBackOffice)

                For Each pCRM As CRMItem In pobjCRM.Values
                    If SearchString = "" Or pCRM.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                        lstCRM.Items.Add(pCRM)
                    End If
                Next
                If mobjPNR.NewElements.CRMCode.TextRequested <> "" And lstCRM.Items.Count = 1 Then
                    Try
                        mflgLoading = True
                        Dim pCRMItem As CRMItem
                        pCRMItem = CType(lstCRM.Items(0), CRMItem)
                        SelectCRM(pCRMItem)
                        txtCRM.Text = lstCRM.Items(0).ToString
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        mflgLoading = False
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw New Exception("PopulateCRMList()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PopulateCustomerList(ByVal SearchString As String)

        Try
            Dim pCustomers As New CustomerCollection
            pCustomers.Load(SearchString, MySettings.PCCBackOffice)
            lstCustomers.Items.Clear()
            For Each pItem As CustomerItem In pCustomers.Values
                If SearchString = "" Or pItem.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                    lstCustomers.Items.Add(pItem)
                End If
            Next
            If lstCustomers.Items.Count = 1 Then
                Try
                    mflgLoading = True
                    Dim pCust As CustomerItem = CType(lstCustomers.Items(0), CustomerItem)
                    SelectCustomer(pCust)
                    txtCustomer.Text = lstCustomers.Items(0).ToString
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    mflgLoading = False
                End Try
            End If
        Catch ex As Exception
            Throw New Exception("PopulateCustomerList()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PopulateSubdepartmentsList(ByVal SearchString As String)

        Try
            Dim pobjSubDepartments As New SubDepartmentCollection

            If SearchString = "" Then
                mobjSubDepartmentSelected = Nothing
                mobjPNR.NewElements.SetSubDepartment(0, "", "")
            End If
            lstSubDepartments.Items.Clear()

            If Not mobjCustomerSelected Is Nothing Then
                pobjSubDepartments.Load(mobjCustomerSelected.ID, MySettings.PCCBackOffice)

                For Each pSubDepartment As SubDepartmentItem In pobjSubDepartments.Values
                    If SearchString = "" Or pSubDepartment.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                        lstSubDepartments.Items.Add(pSubDepartment)
                    End If
                Next

                If lstSubDepartments.Items.Count = 1 Then
                    Try
                        mflgLoading = True
                        Dim pSubDepartmentItem As SubDepartmentItem
                        pSubDepartmentItem = CType(lstSubDepartments.Items(0), SubDepartmentItem)
                        SelectSubDepartment(pSubDepartmentItem)
                        txtSubdepartment.Text = lstSubDepartments.Items(0).ToString
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        mflgLoading = False
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw New Exception("PopulateSubdepartmentsList()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PopulateVesselsList()

        Try
            Dim pobjVessels As New VesselCollection

            lstVessels.Items.Clear()

            If Not mobjCustomerSelected Is Nothing Then

                pobjVessels.Load(mobjCustomerSelected.ID, MySettings.PCCBackOffice)

                For Each pVessel As VesselItem In pobjVessels.Values
                    If mobjPNR.NewElements.VesselName.TextRequested = "" Or pVessel.ToString.ToUpper.Contains(mobjPNR.NewElements.VesselName.TextRequested.ToUpper) Then
                        lstVessels.Items.Add(pVessel)
                    End If
                Next
                If lstVessels.Items.Count = 1 Then
                    Try
                        mflgLoading = True
                        Dim pVesselItem As VesselItem = CType(lstVessels.Items(0), VesselItem)
                        SelectVessel(pVesselItem)
                        txtVessel.Text = lstVessels.Items(0).ToString
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        mflgLoading = False
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw New Exception("PopulateVesselsList()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub DisplayCustomer()

        Dim pstrCustomerCode As String
        Dim pintSubDepartment As Integer
        Dim pstrCRM As String
        Dim pstrVesselName As String
        Dim pstrVesselRegistration As String

        Try
            With mobjPNR.ExistingElements
                pstrCustomerCode = .CustomerCode.Key
                pintSubDepartment = If(IsNumeric(.SubDepartmentCode.Key), CInt(.SubDepartmentCode.Key), 0)
                pstrCRM = .CRMCode.Key
                pstrVesselName = .VesselName.Key
                pstrVesselRegistration = .VesselFlag.Key

                mobjPNR.NewElements.ClearCustomerElements()

                txtCustomer.Clear()
                txtSubdepartment.Clear()
                txtCRM.Clear()
                txtVessel.Clear()

                txtReference.Text = .Reference.Key
                txtSubdepartment.Text = .SubDepartmentCode.Key
                txtCRM.Text = .CRMCode.Key
            End With

            If pstrCustomerCode <> "" Then
                Dim pCustomer As New CustomerItem
                pCustomer.Load(pstrCustomerCode, MySettings.PCCBackOffice)
                txtCustomer.Text = pCustomer.Code
                If pintSubDepartment <> 0 Then
                    Dim pSub As New SubDepartmentItem
                    pSub.Load(pintSubDepartment, MySettings.PCCBackOffice)
                    txtSubdepartment.Text = pSub.Code & " " & pSub.Name
                End If
                If Not pstrCRM Is Nothing AndAlso pstrCRM.Length > 0 Then
                    Dim pSub As New CRMItem
                    pSub.Load(pstrCRM, MySettings.PCCBackOffice)
                    txtCRM.Text = pSub.Code & " " & pSub.Name
                End If

                If pstrVesselName <> "" Then
                    Dim pVessel As New VesselItem
                    If pVessel.Load(pstrCustomerCode, pstrVesselName, MySettings.PCCBackOffice) Then
                        mobjPNR.NewElements.VesselNameForPNR.Clear()
                        mobjPNR.NewElements.VesselFlagForPNR.Clear()
                        txtVessel.Text = pVessel.Name
                    Else
                        mobjPNR.NewElements.SetVesselForPNR(pstrVesselName, pstrVesselRegistration)
                        txtVessel.Text = mobjPNR.NewElements.VesselNameForPNR.TextRequested & " REG " & mobjPNR.NewElements.VesselFlagForPNR.TextRequested
                    End If
                End If

                DisplayOldCustomProperty(cmbBookedby, mobjPNR.ExistingElements.BookedBy)
                DisplayOldCustomProperty(cmbDepartment, mobjPNR.ExistingElements.Department)
                DisplayOldCustomProperty(cmbReasonForTravel, mobjPNR.ExistingElements.ReasonForTravel)
                DisplayOldCustomProperty(cmbCostCentre, mobjPNR.ExistingElements.CostCentre)
                DisplayOldCustomProperty(txtTrId, mobjPNR.ExistingElements.TRId)

                txtReference.Text = mobjPNR.ExistingElements.Reference.Key
                PrepareAdditionalEntries()
            End If
        Catch ex As Exception
            Throw New Exception("DisplayCustomer()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PrepareAdditionalEntries()
        lstAirlineEntries.Items.Clear()
        PrepareAirlinePoints()
        If Not mobjPNR.SSRCTCExists Then
            PrepareCTC()
        End If
    End Sub
    Private Sub PrepareCTC()
        Try
            Dim pFound As String = ""
            Dim pNotFound As String = ""
            mobjCTC.Load(MySettings.PCCBackOffice, mobjCustomerSelected.ID)
            For Each pPax As GDSPaxItem In mobjPNR.Passengers.Values
                Dim pCTCCommand() As String = {""}
                Dim pCTCFound As Boolean = False
                For Each pCTC As CTCPax In mobjCTC.Values
                    If pPax.FirstName = pCTC.FirstName And pPax.LastName = pCTC.Lastname Then
                        pCTCCommand = PrepareCTCCommand(pPax.ElementNo, pCTC)
                        pCTCFound = (pCTCCommand(0) <> "")
                        Exit For
                    End If
                Next
                If Not pCTCFound Then
                    For Each pCTC As CTCPax In mobjCTC.Values
                        If pCTC.Vesselname = mobjPNR.VesselName And pCTC.FirstName = "" And pCTC.Lastname = "" Then
                            pCTCCommand = PrepareCTCCommand(pPax.ElementNo, pCTC)
                            pCTCFound = (pCTCCommand(0) <> "")
                            Exit For
                        End If
                    Next
                End If
                If Not pCTCFound Then
                    For Each pCTC As CTCPax In mobjCTC.Values
                        If pCTC.Vesselname = "" And pCTC.FirstName = "" And pCTC.Lastname = "" Then
                            pCTCCommand = PrepareCTCCommand(pPax.ElementNo, pCTC)
                            pCTCFound = (pCTCCommand(0) <> "")
                            Exit For
                        End If
                    Next
                End If
                If pCTCFound Then
                    For i As Integer = 0 To pCTCCommand.GetUpperBound(0)
                        If pCTCCommand(i) <> "" Then
                            lstAirlineEntries.Items.Add(pCTCCommand(i), True)
                        End If
                    Next
                    pFound &= pPax.ElementNo & " "
                Else
                    pNotFound &= pPax.ElementNo & " "
                End If
            Next

            Dim pSSR As Boolean = False
            If mflgReadPNR AndAlso mobjPNR.SSRCTCExists Then
                pSSR = True
            End If
            SetCTCExists(pSSR, pFound, pNotFound)

        Catch ex As Exception
            Throw New Exception("PrepareCTC()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function PrepareCTCCommand(ByVal pPaxNumber As Integer, ByVal pCTC As CTCPax) As String()
        Dim pCommand() As String = {""}
        Dim pCommandCounter As Integer = 0
        If pCTC.Refused Then
            pCommandCounter += 1
            ReDim Preserve pCommand(pCommandCounter - 1)
            If mobjPNR.GDSCode = EnumGDSCode.Galileo Then
                pCommand(pCommandCounter - 1) = "SI.P" & pPaxNumber & "/SSRCTCRYYHK1/PASSENGER REFUSED TO PROVIDE INFORMATION"
            Else
                pCommand(pCommandCounter - 1) = "SRCTCR-PASSENGER REFUSED TO PROVIDE INFORMATION/P" & pPaxNumber
            End If
        Else
            If pCTC.Email <> "" Then
                pCommandCounter += 1
                ReDim Preserve pCommand(pCommandCounter - 1)
                If mobjPNR.GDSCode = EnumGDSCode.Galileo Then
                    pCommand(pCommandCounter - 1) = "SI.P" & pPaxNumber & "/SSRCTCEYYHK1/" & pCTC.Email.Replace("@", "//").Replace("_", "..").Replace("-", "./")
                Else
                    pCommand(pCommandCounter - 1) = "SRCTCE-" & pCTC.Email.Replace("@", "//").Replace("_", "..").Replace("-", "./") & "/P" & pPaxNumber
                End If
            End If
            If pCTC.Mobile <> "" Then
                pCommandCounter += 1
                ReDim Preserve pCommand(pCommandCounter - 1)
                If mobjPNR.GDSCode = EnumGDSCode.Galileo Then
                    pCommand(pCommandCounter - 1) = "SI.P" & pPaxNumber & "/SSRCTCMYYHK1/" & pCTC.Mobile
                Else
                    pCommand(pCommandCounter - 1) = "SRCTCM-" & pCTC.Mobile & "/P" & pPaxNumber
                End If
            End If
        End If
        Return pCommand
    End Function
    Private Sub PrepareAirlinePoints()
        Try
            Dim pFound As Boolean = False

            If mobjCustomerSelected.ID <> 0 Then
                'Dim pAirlinePoints As New AirlinePointsCollection
                For Each pSeg As GDSSegItem In mobjPNR.Segments.Values
                    If Not mobjVesselSelected Is Nothing Then
                        mobjAirlinePoints.Load(mobjCustomerSelected.ID, mobjVesselSelected.Name, pSeg.Airline, mobjPNR.GDSCode, MySettings.PCCBackOffice)
                    Else
                        mobjAirlinePoints.Load(mobjCustomerSelected.ID, "", pSeg.Airline, mobjPNR.GDSCode, MySettings.PCCBackOffice)
                    End If

                    For Each pItem As String In mobjAirlinePoints
                        pFound = False
                        For i As Integer = 0 To lstAirlineEntries.Items.Count - 1
                            If lstAirlineEntries.Items(i).ToString = pItem.ToString Then
                                pFound = True
                                Exit For
                            End If
                        Next
                        If Not pFound Then
                            lstAirlineEntries.Items.Add(pItem, True)
                        End If
                    Next
                Next
            End If

            If mflgReadPNR Then
                Dim pAirlineNotes As New AirlineNotesCollection
                For Each pSeg As GDSSegItem In mobjPNR.Segments.Values
                    pAirlineNotes.Load(pSeg.Airline, mobjPNR.GDSCode)
                    For Each pItem As AirlineNotesItem In pAirlineNotes.Values
                        With pItem
                            If Not .Seaman Or Not mobjVesselSelected Is Nothing Then
                                Dim pGDSText As String = .GDSEntry

                                If pGDSText.Contains("<?VESSEL NAME>") Then
                                    If Not mobjVesselSelected Is Nothing Then
                                        If mobjVesselSelected.Name Is Nothing Then
                                            pGDSText = pGDSText.Replace("<?VESSEL NAME>", mobjVesselSelected.Name)
                                        Else
                                            pGDSText = pGDSText.Replace("<?VESSEL NAME>", mobjVesselSelected.Name.Replace("(", "-").Replace(")", "-").Replace("&", "-"))
                                        End If
                                    End If
                                End If

                                If pGDSText.Contains("<?VESSEL REGISTRATION>") Then
                                    If Not mobjVesselSelected Is Nothing Then
                                        If mobjVesselSelected.Flag Is Nothing Then
                                            pGDSText = pGDSText.Replace("<?VESSEL REGISTRATION>", mobjVesselSelected.Flag)
                                        Else
                                            pGDSText = pGDSText.Replace("<?VESSEL REGISTRATION>", mobjVesselSelected.Flag.Replace("(", "-").Replace(")", "-").Replace("&", "-"))
                                        End If
                                    End If
                                End If

                                If pGDSText.Contains("<?NBR OF PSGRS>") Then
                                    pGDSText = pGDSText.Replace("<?NBR OF PSGRS>", CStr(mobjPNR.NumberOfPax))
                                End If

                                If pGDSText.Contains("<?Segment selection>") Then
                                    pGDSText = pGDSText.Replace("<?Segment selection>", CStr(pSeg.ElementNo))
                                End If

                                Dim pGDSCommand As String = pGDSText
                                pFound = False
                                For i As Integer = 0 To lstAirlineEntries.Items.Count - 1
                                    If lstAirlineEntries.Items(i).ToString = pGDSCommand Then
                                        pFound = True
                                        Exit For
                                    End If
                                Next
                                If Not pFound Then
                                    lstAirlineEntries.Items.Add(pGDSCommand, True)
                                End If

                            End If
                        End With
                    Next
                Next

                If Not mobjCustomerSelected Is Nothing And Not mobjVesselSelected Is Nothing Then
                    Dim pConditionalEntry As New ConditionalGDSEntryCollection
                    pConditionalEntry.Load(MySettings.PCCBackOffice, mobjCustomerSelected.ID, mobjVesselSelected.Name)
                    For Each pItem As ConditionalGDSEntryItem In pConditionalEntry.Values
                        Dim pGDSCommand As String = ""
                        If mSelectedGDSCode = EnumGDSCode.Amadeus Then
                            pGDSCommand = pItem.ConditionalEntry1A
                        ElseIf mSelectedGDSCode = EnumGDSCode.Galileo Then
                            pGDSCommand = pItem.ConditionalEntry1G
                        Else
                            pGDSCommand = ""
                        End If
                        If pGDSCommand <> "" Then
                            pFound = False
                            For i As Integer = 0 To lstAirlineEntries.Items.Count - 1
                                If lstAirlineEntries.Items(i).ToString = pGDSCommand Then
                                    pFound = True
                                    Exit For
                                End If
                            Next
                            If Not pFound Then
                                lstAirlineEntries.Items.Add(pGDSCommand, True)
                            End If

                        End If

                    Next
                End If
            End If
        Catch aex As System.ArgumentOutOfRangeException
            MessageBox.Show(aex.Message)
        Catch ex As Exception
            Throw New Exception("PrepareAirlinePoints()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub SelectCRM(ByVal pCRM As CRMItem)

        Try
            mobjCRMSelected = pCRM
            txtCRM.Text = pCRM.ToString
            mobjPNR.NewElements.SetCRM(mobjCRMSelected.ID, mobjCRMSelected.Code, mobjCRMSelected.Name)

            SetEnabled()
            If pCRM.Alert <> "" Then
                MessageBox.Show(pCRM.Alert, pCRM.Code & " " & pCRM.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw New Exception("SelectCRM()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SelectCustomer(ByVal pCustomer As CustomerItem)

        Try
            mobjPNR.NewElements.ClearCustomerElements()
            mobjCustomerSelected = pCustomer
            txtCustomer.Text = pCustomer.ToString
            mobjPNR.NewElements.SetItem(mobjCustomerSelected, MySettings.PCCBackOffice)

            txtSubdepartment.Clear()
            lstSubDepartments.Items.Clear()
            mobjSubDepartmentSelected = Nothing

            txtCRM.Clear()
            lstCRM.Items.Clear()
            mobjCRMSelected = Nothing

            txtVessel.Clear()
            lstVessels.Items.Clear()
            mobjVesselSelected = Nothing

            txtReference.Clear()

            cmbBookedby.Text = ""
            cmbDepartment.Text = ""
            txtTrId.Clear()

            If mobjCustomerSelected.HasVessels Then
                PopulateVesselsList()
            End If

            If mobjCustomerSelected.HasDepartments Then
                PopulateSubdepartmentsList("")
            End If

            PopulateCRMList("")
            PopulateCustomProperties()
            PrepareAdditionalEntries()

            SetEnabled()

            If pCustomer.AlertForFinisher <> "" Then
                MessageBox.Show(pCustomer.AlertForFinisher, pCustomer.Code & " " & pCustomer.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw New Exception("SelectCustomer()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PopulateCustomProperties()

        Try
            cmbBookedby.Items.Clear()
            cmbDepartment.Items.Clear()
            cmbReasonForTravel.Items.Clear()
            cmbCostCentre.Items.Clear()
            cmbBookedby.Enabled = False
            cmbDepartment.Enabled = False
            cmbReasonForTravel.Enabled = False
            cmbCostCentre.Enabled = False
            txtTrId.Enabled = False

            If Not mobjCustomerSelected Is Nothing Then
                For Each pProp As CustomPropertiesItem In mobjCustomerSelected.CustomerProperties.Values
                    If pProp.CustomPropertyID = EnumCustomPropertyID.BookedBy Then
                        PrepareCustomProperty(cmbBookedby, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.Department Then
                        PrepareCustomProperty(cmbDepartment, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.ReasonFortravel Then
                        PrepareCustomProperty(cmbReasonForTravel, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.CostCentre Then
                        PrepareCustomProperty(cmbCostCentre, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.TRId Then
                        PrepareCustomProperty(txtTrId, pProp)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw New Exception("PopulateCustomproperties()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PrepareCustomProperty(ByRef cmbCombo As ComboBox, ByRef pProp As CustomPropertiesItem)

        Try
            cmbCombo.Enabled = True
            cmbCombo.Tag = pProp
            If pProp.LimitToLookup Then
                cmbCombo.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                cmbCombo.DropDownStyle = ComboBoxStyle.DropDown
            End If
            cmbCombo.AutoCompleteSource = AutoCompleteSource.ListItems
            cmbCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            If pProp.RequiredType = CustomPropertyRequiredType.PropertyOptional Then
                cmbCombo.Items.Add("")
            End If
            For Each pItem As CustomPropertiesValues In pProp.Value.Values
                cmbCombo.Items.Add(pItem.Value)
            Next
            'For i As Integer = 0 To pProp.ValuesCount - 1
            '    cmbCombo.Items.Add(pProp.Value(i))
            'Next
        Catch ex As Exception
            Throw New Exception("PrepareCustomProperty()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PrepareCustomProperty(ByRef txtText As TextBox, ByRef pProp As CustomPropertiesItem)

        Try
            txtText.Enabled = True
            txtText.Tag = pProp
        Catch ex As Exception
            Throw New Exception("PrepareCustomProperty()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SelectSubDepartment(ByVal pSubDepartment As SubDepartmentItem)

        Try
            mobjSubDepartmentSelected = pSubDepartment
            txtSubdepartment.Text = pSubDepartment.ToString
            mobjPNR.NewElements.SetSubDepartment(mobjSubDepartmentSelected.ID, mobjSubDepartmentSelected.Code, mobjSubDepartmentSelected.Name)

            SetEnabled()
        Catch ex As Exception
            Throw New Exception("SelectSubDepartment()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SelectVessel(ByVal pVessel As VesselItem)

        Try
            mobjVesselSelected = pVessel
            txtVessel.Text = pVessel.ToString
            mobjPNR.NewElements.SetItem(mobjVesselSelected)
            PrepareAdditionalEntries()
            SetEnabled()
        Catch ex As Exception
            Throw New Exception("SelectVessel()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SetEnabled()

        Try
            ' read PNR is always enabled
            cmdPNRRead1APNR.Enabled = True

            ' customer based entries are enabled if a PNR has been read and there is data available
            txtCustomer.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)
            lstCustomers.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)
            cmdCostCentre.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)

            txtSubdepartment.Enabled = mflgReadPNR And (lstSubDepartments.Items.Count > 0)
            lstSubDepartments.Enabled = mflgReadPNR And (lstSubDepartments.Items.Count > 0)

            txtCRM.Enabled = mflgReadPNR And (lstCRM.Items.Count > 0)
            lstCRM.Enabled = mflgReadPNR And (lstCRM.Items.Count > 0)

            txtVessel.Enabled = mflgReadPNR And (lstVessels.Items.Count > 0)
            lstVessels.Enabled = mflgReadPNR And (lstVessels.Items.Count > 0)

            ' the exception is the one time vessel which is always enabled for any PNR
            cmdOneTimeVessel.Enabled = mflgReadPNR

            ' Update is enabled if a PNR has been read and if mandatory fields have been entered
            cmdPNRWrite.Enabled = False
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False

            ' Customer is always needed

            txtCustomer.BackColor = lstCustomers.BackColor
            txtSubdepartment.BackColor = lstCustomers.BackColor
            txtCRM.BackColor = lstCustomers.BackColor
            If Not mobjPNR Is Nothing Then
                cmdPNRWrite.Enabled = mflgReadPNR
                If Not mobjPNR.NewElements Is Nothing Then
                    If mobjPNR.NewElements.CustomerCode.GDSCommand = "" Then
                        cmdPNRWrite.Enabled = False
                        txtCustomer.BackColor = Color.Red
                    End If

                    ' if subdepartments exist they are by default madatory
                    If mobjPNR.NewElements.CustomerCode.GDSCommand <> "" And lstSubDepartments.Items.Count > 0 And mobjPNR.NewElements.SubDepartmentCode.GDSCommand = "" Then
                        cmdPNRWrite.Enabled = False
                        txtSubdepartment.BackColor = Color.Red
                    End If

                    ' the code above is complete validation but allow entry without CRM in any case
                    If mobjPNR.NewElements.CustomerCode.GDSCommand <> "" And lstCRM.Items.Count > 0 And mobjPNR.NewElements.CRMCode.GDSCommand = "" Then
                        txtCRM.BackColor = Color.Pink
                    End If
                    SetClientReferencesEnabled(mobjPNR.NewElements.BookedBy, lblBookedByHighlight, cmbBookedby)
                    SetClientReferencesEnabled(mobjPNR.NewElements.CostCentre, lblCostCentreHighlight, cmbCostCentre)
                    SetClientReferencesEnabled(mobjPNR.NewElements.Department, lblDepartmentHighlight, cmbDepartment)
                    SetClientReferencesEnabled(mobjPNR.NewElements.ReasonForTravel, lblReasonForTravelHighLight, cmbReasonForTravel)
                    SetClientReferencesEnabled(mobjPNR.NewElements.TRId, lblTRIDHighLight, txtTrId)
                End If

                cmdPNRWriteWithDocs.Enabled = cmdPNRWrite.Enabled And mflgAPISUpdate
                cmdPNROnlyDocs.Enabled = mflgAPISUpdate And Not mobjPNR.NewPNR
            End If

            dgvApis.Enabled = True
            txtReference.Enabled = True

            lblBookedByHighlight.Enabled = (cmbBookedby.Enabled)
            lblDepartmentHighlight.Enabled = (cmbDepartment.Enabled)
            lblReasonForTravelHighLight.Enabled = (cmbReasonForTravel.Enabled)
            lblCostCentreHighlight.Enabled = (cmbCostCentre.Enabled)
            lblTRIDHighLight.Enabled = (txtTrId.Enabled)

            SetLabelColor(lblBookedByHighlight, CType(cmbBookedby.Tag, CustomPropertiesItem))
            SetLabelColor(lblCostCentreHighlight, CType(cmbCostCentre.Tag, CustomPropertiesItem))
            SetLabelColor(lblDepartmentHighlight, CType(cmbDepartment.Tag, CustomPropertiesItem))
            SetLabelColor(lblReasonForTravelHighLight, CType(cmbReasonForTravel.Tag, CustomPropertiesItem))
            SetLabelColor(lblTRIDHighLight, CType(txtTrId.Tag, CustomPropertiesItem))
        Catch ex As Exception
            Throw New Exception("SetEnabled()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SetClientReferencesEnabled(ByRef pNewItem As GDSNewItem, ByRef pLabel As Label, ByRef pCombo As ComboBox)

        Dim pProps As CustomPropertiesItem

        If pNewItem.GDSCommand = "" Then
            pLabel.Text = ""
            If pCombo.Enabled Then
                pProps = CType(pCombo.Tag, CustomPropertiesItem)
                If Not pProps Is Nothing Then
                    pLabel.Text = pProps.Label
                    If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                        cmdPNRWrite.Enabled = False
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub SetClientReferencesEnabled(ByRef pNewItem As GDSNewItem, ByRef pLabel As Label, ByRef pText As TextBox)

        Dim pProps As CustomPropertiesItem

        If pNewItem.GDSCommand = "" Then
            pLabel.Text = ""
            If pText.Enabled Then
                pProps = CType(pText.Tag, CustomPropertiesItem)
                If Not pProps Is Nothing Then
                    pLabel.Text = pProps.Label
                    If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                        cmdPNRWrite.Enabled = False
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub SetCTCExists(ByVal pSSRExists As Boolean, ByVal pPaxFound As String, ByVal pPaxNotFound As String)
        Try
            If pSSRExists Then
                lblCTC.BackColor = Color.Cyan
                lblCTC.Text = "CTC in PNR"
            ElseIf pPaxFound <> "" And pPaxNotFound = "" Then
                lblCTC.BackColor = Color.LightGreen
                lblCTC.Text = "CTC exists"
            Else
                lblCTC.BackColor = Color.Red
                lblCTC.Text = "CTC Missing"
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub SetLabelColor(ByRef TextLabel As Label, ByVal CustomProps As CustomPropertiesItem)
        Try
            If TextLabel.Enabled Then
                If Not CustomProps Is Nothing AndAlso CustomProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                    TextLabel.BackColor = Color.FromArgb(255, 128, 128)
                Else
                    TextLabel.BackColor = Color.Cyan
                End If
            Else
                TextLabel.BackColor = Color.Silver
            End If
        Catch ex As Exception
            Throw New Exception("SetLabelColor()" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub PrepareLists()

        Try
            lstCustomers.Items.Clear()

            lstSubDepartments.Items.Clear()
            mobjSubDepartmentSelected = Nothing

            lstCRM.Items.Clear()
            mobjCRMSelected = Nothing

            lstVessels.Items.Clear()
            mobjVesselSelected = Nothing

            cmdPNRWrite.Enabled = False
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False

        Catch ex As Exception
            Throw New Exception("PrepareLists()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Function UpdatePNR(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean) As String
        Try
            UpdatePNR = mobjPNR.SendAllGDSEntries(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, lstAirlineEntries)
            Dim pPNR As String = mobjPNR.PnrNumber
            Dim pNewEntry = False
            If pPNR = "New PNR" Or pPNR = "" Then
                If UpdatePNR.LastIndexOf(" ") > -1 Then
                    pPNR = UpdatePNR.Substring(UpdatePNR.LastIndexOf(" ")).Trim
                ElseIf UpdatePNR.Length = 6 Then
                    pPNR = UpdatePNR
                End If
                pNewEntry = True
            End If
            Dim pClient As String = mobjPNR.ClientCode
            If pClient = "" Then
                pClient = mobjPNR.NewElements.CustomerCode.TextRequested
            End If
            If pPNR <> "" Then
                PNRFinisherTransactions.UpdateTransactions(pPNR, MySettings.GDSAbbreviation, MySettings.GDSPcc, MySettings.GDSUser, Now, mobjPNR.Passengers.AllPassengers, mobjPNR.Segments.FullItinerary, "", pClient, pNewEntry)
            End If
        Catch ex As Exception
            Throw New Exception("UpdatePNR()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub cmdAPISEditPax_Click(sender As Object, e As EventArgs) Handles cmdAPISEditPax.Click

        Try
            Dim pFrm As New frmAPISPax
            If pFrm.ShowDialog(Me) = DialogResult.OK Then
                APISDisplayPax()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ReadPNR()
        Dim pDMI As String
        Try
            With mobjPNR
                mflgReadPNR = False
                Dim mGDSUser As New GDSUser(mSelectedGDSCode)
                InitSettings(mGDSUser)
                SetupPCCOptions()
                pDMI = .Read()
                If .NumberOfPax = 0 And Not .IsGroup Then
                    Throw New Exception("Need passenger names")
                End If
                If pDMI <> "" Then
                    If MessageBox.Show("There is a problem with your itinerary. Do you want to cancel the PNR Finisher?" & vbCrLf & vbCrLf & pDMI, "Itinerary Check", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        Throw New Exception("PNR Finisher cancelled because of itinerary check")
                    End If
                End If

                mflgReadPNR = True
                .PrepareNewGDSElements()
                lblPNR.Text = .PnrNumber
                If .IsGroup Then
                    lblPax.Text = "Group:" & .GroupName & " " & .GroupNamesCount
                Else
                    lblPax.Text = .PaxLeadName
                End If

                lblSegs.Text = .Itinerary
                If .Segments.AirlineAlert <> "" Then
                    MessageBox.Show(.Segments.AirlineAlert, "AIRLINE ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                PrepareAdditionalEntries()
            End With
            DisplayCustomer()
            APISDisplayPax()

        Catch ex As Exception
            Throw New Exception("ReadPNR()" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvApis_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApis.CellValueChanged
        Try
            dgvApis.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dgvApis.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.ToUpper
        Catch ex As Exception

        End Try
        APISValidateDataRow(dgvApis.Rows(e.RowIndex))
    End Sub
    Private Sub dgvApis_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvApis.CurrentCellDirtyStateChanged
        cmdPNROnlyDocs.Enabled = False
        cmdPNRWriteWithDocs.Enabled = False
    End Sub
    Private Sub dgvApis_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvApis.RowValidating
        APISValidateDataRow(dgvApis.Rows(e.RowIndex))
    End Sub

    Private Sub DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As GDSExistingItem)
        Try
            If Item.Key <> "" Then
                If cmbList.DropDownStyle = ComboBoxStyle.DropDown Then
                    If Item.Key <> "" Then
                        cmbList.Text = Item.Key
                    End If
                Else
                    For i As Integer = 0 To cmbList.Items.Count - 1
                        If Item.Key.ToUpper = cmbList.Items(i).ToString.ToUpper Then
                            cmbList.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw New Exception("DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As GDSExisting.Item)" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DisplayOldCustomProperty(ByRef txtText As TextBox, ByVal Item As GDSExistingItem)
        Try
            txtText.Text = Item.Key
        Catch ex As Exception
            Throw New Exception("DisplayOldCustomProperty(ByRef txtText As TextBox, ByVal Item As GDSExisting.Item)" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As String)
        Try
            If Item <> "" Then
                If cmbList.DropDownStyle = ComboBoxStyle.DropDown Then
                    cmbList.Text = Item
                Else
                    For i As Integer = 0 To cmbList.Items.Count - 1
                        If cmbList.Items(i).ToString.ToUpper.StartsWith(Item.ToUpper) Then
                            cmbList.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw New Exception("DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As String)" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub ClearForm()

        Try
            mobjCustomerSelected = New CustomerItem
            mobjSubDepartmentSelected = New SubDepartmentItem
            mobjCRMSelected = New CRMItem
            mobjVesselSelected = New VesselItem
            mobjAirlinePoints = New AirlinePointsCollection
            mobjCTC = New CTCPaxCollection
            mfrmCTC.Dispose()
            mfrmCTCPax.Dispose()
            lblPNR.Text = ""
            lblPax.Text = ""
            lblSegs.Text = ""

            txtCustomer.Clear()
            txtSubdepartment.Clear()
            txtCRM.Clear()
            txtVessel.Clear()
            lstAirlineEntries.Items.Clear()

            lstVessels.Items.Clear()

            lstSubDepartments.Items.Clear()
            txtSubdepartment.Enabled = (lstSubDepartments.Items.Count > 0)

            lstCRM.Items.Clear()
            txtCRM.Enabled = (lstCRM.Items.Count > 0)

            txtReference.Clear()
            cmbDepartment.Items.Clear()
            cmbDepartment.Text = ""
            cmbDepartment.Tag = Nothing
            cmbBookedby.Items.Clear()
            cmbBookedby.Text = ""
            cmbBookedby.Tag = Nothing
            cmbReasonForTravel.Items.Clear()
            cmbReasonForTravel.Text = ""
            cmbReasonForTravel.Tag = Nothing
            cmbCostCentre.Items.Clear()
            cmbCostCentre.Text = ""
            cmbCostCentre.Tag = Nothing
            txtTrId.Clear()
            txtTrId.Tag = Nothing

            cmdPNRWrite.Enabled = False
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False
            'cmdPriceOptimiser.Enabled = False
            'If Not MySettings Is Nothing AndAlso MySettings.PriceOptimiser Then
            '    cmdPriceOptimiser.Visible = True
            'Else
            '    cmdPriceOptimiser.Visible = False
            'End If

            mobjPNR.ExistingElements.Clear()
            mobjPNR.NewElements.Clear()

            mflgAPISUpdate = False
            mflgExpiryDateOK = False

            APISPrepareGrid(dgvApis)

        Catch ex As Exception
            Throw New Exception("ClearForm()" & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Function PNRWrite(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean) As String

        Try
            PNRWrite = UpdatePNR(WritePNR, WriteDocs)
            If mSelectedGDSCode = EnumGDSCode.Galileo And PNRWrite.Length > 6 Then
                MessageBox.Show("Please enter *R or *ALL in Galileo to show the PNR" & If(PNRWrite <> "", vbCrLf & vbCrLf & "PNR: " & PNRWrite, ""), "Galileo Information for PNR")
            End If
            mflgReadPNR = False
            ClearForm()
            SetEnabled()
        Catch ex As Exception
            Throw New Exception("PNRWrite(" & WritePNR & ", " & WriteDocs & ")" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub PNRReadPNR()
        Try
            ClearForm()
            ReadPNR()
            ShowPriceOptimiser(Me.MdiParent, False)
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetupPCCOptions()
        Try
            mflgLoading = True
            Dim pText As String = ""
            If MySettings.GDSPcc <> "" And MySettings.GDSUser <> "" Then
                pText &= MySettings.GDSPcc & " " & MySettings.GDSUser
                SSGDS.Text = MySettings.GDSAbbreviation
                SSPCC.Text = MySettings.GDSPcc
                SSUser.Text = MySettings.GDSUser
            Else
                Throw New Exception("No GDS signed in")
            End If

            If CheckOptions() Then
                ' finisher tab
                mflgReadPNR = False
                ClearForm()
                SetEnabled()
                PrepareForm()
                APISPrepareGrid(dgvApis)

            Else
                Throw New Exception("User not authorized for this PCC")
            End If
        Catch ex As Exception
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub cmdItineraryHelper_Click(sender As Object, e As EventArgs) Handles cmdItineraryHelper.Click

        Try
            If mfrmItinHelper Is Nothing OrElse mfrmItinHelper.IsDisposed Then
                mfrmItinHelper = New frmItineraryHelper()
            End If
            mfrmItinHelper.Location = Me.Location
            If Not mobjPNR Is Nothing AndAlso mobjPNR.Itinerary Is Nothing Then
                mfrmItinHelper.DisplayItinerary(mobjPNR.Itinerary)
            Else
                mfrmItinHelper.DisplayItinerary("")
            End If

            mfrmItinHelper.Show()
            mfrmItinHelper.BringToFront()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdCTCForm_Click(sender As Object, e As EventArgs) Handles cmdCTCForm.Click

        Try
            Dim pClientId As Integer = 0
            Dim pClientCode As String = ""
            Dim pClientName As String = ""
            Dim pVessel As String = ""
            If Not mobjCustomerSelected Is Nothing AndAlso mobjCustomerSelected.ID > 0 Then
                pClientId = mobjCustomerSelected.ID
                pClientCode = mobjCustomerSelected.Code
                pClientName = mobjCustomerSelected.Name
            End If
            If Not mobjVesselSelected Is Nothing Then
                pVessel = mobjVesselSelected.Name
            End If

            If pClientCode = "" Or mobjPNR.Passengers.Count = 0 Then
                If mfrmCTC.IsDisposed Then
                    mfrmCTC = New frmPaxCTC
                End If
                mfrmCTC.Location = Me.Location
                mfrmCTC.ShowPaxInformation()
                mfrmCTC.ShowDialog()
            Else
                If mfrmCTCPax.IsDisposed Then
                    mfrmCTCPax = New frmPaxCTCOnlyPax
                End If
                mfrmCTCPax.Location = Me.Location
                mfrmCTCPax.ShowPaxInformation(mobjPNR, MySettings.PCCBackOffice, pClientId, pClientCode, pClientName, pVessel)
                mfrmCTCPax.ShowDialog()
                PrepareAdditionalEntries()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Private Sub llbOptions_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbOptions.LinkClicked

    '    Try
    '        ShowOptionsForm()

    '        If Not CheckOptions() Then
    '            Me.Close()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub
    Private Sub ShowOptionsForm()
        Try
            Dim pFrm As New frmShowOptions
            pFrm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function CheckOptions() As Boolean
        Try
            With MySettings
                While Not .isValid
                    If MessageBox.Show("Please enter your details", "Options Missing", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                        Return False
                    End If
                    ShowOptionsForm()
                End While
                Return True
            End With
        Catch ex As Exception
            Throw New Exception("CheckOptions()" & vbCrLf & ex.Message)
        End Try

    End Function
    '    Private Sub ShowPriceOptimiser()
    '        If Not MySettings Is Nothing Then
    '            If MySettings.PriceOptimiser Then
    '                If MySettings.GDSPcc <> "" And MySettings.GDSUser <> "" Then
    '                    Dim pPCC As String = MySettings.GDSPcc
    '                    Dim pUserId As String = MySettings.GDSUser
    '                    ' for testing only
    '#If DEBUG Then
    '                    'pPCC = "750B"
    '                    'pUserId = "038981"
    '#End If
    '                    'pPCC = "750B"
    '                    'pUserId = "051244"
    '                    'Dim pDownsell As New DownsellCollection
    '                    'If pDownsell.CountNonVerified(pPCC, pUserId) > 0 Then
    '                    If mfrmOptimiser Is Nothing OrElse mfrmOptimiser.IsDisposed Then
    '                        mfrmOptimiser = New frmPriceOptimiser
    '                    End If
    '                    mfrmOptimiser.DisplayItems(pPCC, pUserId, Me.Height, Me.Width)
    '                    If mfrmOptimiser.FormIsExpanded Then
    '                        mfrmOptimiser.Show()
    '                        mfrmOptimiser.BringToFront()
    '                    End If
    '                    'End If
    '                End If
    '            End If
    '        End If
    '    End Sub

    Private Sub PrepareForm()

        Try
            PrepareLists()
            PopulateCustomerList("")
        Catch ex As Exception
            Throw New Exception("PrepareForms()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub frm02Finisher_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            mflgLoading = True
            dgvApis.VirtualMode = False
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

End Class