<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm02Finisher
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblCTC = New System.Windows.Forms.Label()
        Me.cmdCTCForm = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lstAirlineEntries = New System.Windows.Forms.CheckedListBox()
        Me.txtTrId = New System.Windows.Forms.TextBox()
        Me.lblTRIDHighLight = New System.Windows.Forms.Label()
        Me.txtPNRApis = New System.Windows.Forms.TextBox()
        Me.cmdAPISEditPax = New System.Windows.Forms.Button()
        Me.cmdPNRRead1GPNR = New System.Windows.Forms.Button()
        Me.cmdPNROnlyDocs = New System.Windows.Forms.Button()
        Me.cmdPNRWriteWithDocs = New System.Windows.Forms.Button()
        Me.lblSSRDocs = New System.Windows.Forms.Label()
        Me.dgvApis = New System.Windows.Forms.DataGridView()
        Me.cmdItineraryHelper = New System.Windows.Forms.Button()
        Me.cmdCostCentre = New System.Windows.Forms.Button()
        Me.cmdPNRRead1APNR = New System.Windows.Forms.Button()
        Me.cmdOneTimeVessel = New System.Windows.Forms.Button()
        Me.txtSubdepartment = New System.Windows.Forms.TextBox()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.lblCostCentreHighlight = New System.Windows.Forms.Label()
        Me.cmbCostCentre = New System.Windows.Forms.ComboBox()
        Me.cmdPNRWrite = New System.Windows.Forms.Button()
        Me.lstCRM = New System.Windows.Forms.ListBox()
        Me.lblSegs = New System.Windows.Forms.Label()
        Me.txtVessel = New System.Windows.Forms.TextBox()
        Me.lblReasonForTravelHighLight = New System.Windows.Forms.Label()
        Me.txtCRM = New System.Windows.Forms.TextBox()
        Me.lblPax = New System.Windows.Forms.Label()
        Me.lstSubDepartments = New System.Windows.Forms.ListBox()
        Me.cmbReasonForTravel = New System.Windows.Forms.ComboBox()
        Me.lblSubDepartment = New System.Windows.Forms.Label()
        Me.lblPNR = New System.Windows.Forms.Label()
        Me.lblCRM = New System.Windows.Forms.Label()
        Me.lblDepartmentHighlight = New System.Windows.Forms.Label()
        Me.lstVessels = New System.Windows.Forms.ListBox()
        Me.lblVessel = New System.Windows.Forms.Label()
        Me.lblBookedByHighlight = New System.Windows.Forms.Label()
        Me.lstCustomers = New System.Windows.Forms.ListBox()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.lblReference = New System.Windows.Forms.Label()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.lblAirlinePoints = New System.Windows.Forms.Label()
        Me.cmbBookedby = New System.Windows.Forms.ComboBox()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SSGDS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SSPCC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SSUser = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCTC
        '
        Me.lblCTC.BackColor = System.Drawing.Color.Yellow
        Me.lblCTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCTC.Location = New System.Drawing.Point(987, 61)
        Me.lblCTC.Name = "lblCTC"
        Me.lblCTC.Size = New System.Drawing.Size(91, 39)
        Me.lblCTC.TabIndex = 102
        Me.lblCTC.Text = "CTC"
        Me.lblCTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCTCForm
        '
        Me.cmdCTCForm.Location = New System.Drawing.Point(1084, 61)
        Me.cmdCTCForm.Name = "cmdCTCForm"
        Me.cmdCTCForm.Size = New System.Drawing.Size(116, 39)
        Me.cmdCTCForm.TabIndex = 101
        Me.cmdCTCForm.Text = "Passenger Contact Information (CTC)"
        Me.cmdCTCForm.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(172, 419)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(154, 29)
        Me.Button1.TabIndex = 100
        Me.Button1.Text = "Edit Pax CTC"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstAirlineEntries
        '
        Me.lstAirlineEntries.BackColor = System.Drawing.Color.Aqua
        Me.lstAirlineEntries.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lstAirlineEntries.ForeColor = System.Drawing.Color.Blue
        Me.lstAirlineEntries.FormattingEnabled = True
        Me.lstAirlineEntries.Location = New System.Drawing.Point(644, 241)
        Me.lstAirlineEntries.Name = "lstAirlineEntries"
        Me.lstAirlineEntries.Size = New System.Drawing.Size(687, 169)
        Me.lstAirlineEntries.Sorted = True
        Me.lstAirlineEntries.TabIndex = 97
        '
        'txtTrId
        '
        Me.txtTrId.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtTrId.Location = New System.Drawing.Point(777, 183)
        Me.txtTrId.Name = "txtTrId"
        Me.txtTrId.Size = New System.Drawing.Size(207, 20)
        Me.txtTrId.TabIndex = 81
        '
        'lblTRIDHighLight
        '
        Me.lblTRIDHighLight.BackColor = System.Drawing.Color.Pink
        Me.lblTRIDHighLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblTRIDHighLight.Location = New System.Drawing.Point(644, 180)
        Me.lblTRIDHighLight.Name = "lblTRIDHighLight"
        Me.lblTRIDHighLight.Size = New System.Drawing.Size(125, 27)
        Me.lblTRIDHighLight.TabIndex = 80
        Me.lblTRIDHighLight.Text = "TR ID"
        Me.lblTRIDHighLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPNRApis
        '
        Me.txtPNRApis.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPNRApis.Location = New System.Drawing.Point(1390, 454)
        Me.txtPNRApis.Multiline = True
        Me.txtPNRApis.Name = "txtPNRApis"
        Me.txtPNRApis.ReadOnly = True
        Me.txtPNRApis.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPNRApis.Size = New System.Drawing.Size(28, 18)
        Me.txtPNRApis.TabIndex = 83
        Me.txtPNRApis.Visible = False
        '
        'cmdAPISEditPax
        '
        Me.cmdAPISEditPax.Location = New System.Drawing.Point(12, 419)
        Me.cmdAPISEditPax.Name = "cmdAPISEditPax"
        Me.cmdAPISEditPax.Size = New System.Drawing.Size(154, 29)
        Me.cmdAPISEditPax.TabIndex = 84
        Me.cmdAPISEditPax.Text = "Edit Pax SSRDOCS"
        Me.cmdAPISEditPax.UseVisualStyleBackColor = True
        '
        'cmdPNRRead1GPNR
        '
        Me.cmdPNRRead1GPNR.Location = New System.Drawing.Point(192, 12)
        Me.cmdPNRRead1GPNR.Name = "cmdPNRRead1GPNR"
        Me.cmdPNRRead1GPNR.Size = New System.Drawing.Size(157, 35)
        Me.cmdPNRRead1GPNR.TabIndex = 55
        Me.cmdPNRRead1GPNR.Text = "Read Galileo PNR"
        Me.cmdPNRRead1GPNR.UseVisualStyleBackColor = True
        '
        'cmdPNROnlyDocs
        '
        Me.cmdPNROnlyDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNROnlyDocs.Location = New System.Drawing.Point(1025, 12)
        Me.cmdPNROnlyDocs.Name = "cmdPNROnlyDocs"
        Me.cmdPNROnlyDocs.Size = New System.Drawing.Size(115, 35)
        Me.cmdPNROnlyDocs.TabIndex = 89
        Me.cmdPNROnlyDocs.Text = "Only DOCS"
        Me.cmdPNROnlyDocs.UseVisualStyleBackColor = True
        '
        'cmdPNRWriteWithDocs
        '
        Me.cmdPNRWriteWithDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNRWriteWithDocs.Location = New System.Drawing.Point(792, 12)
        Me.cmdPNRWriteWithDocs.Name = "cmdPNRWriteWithDocs"
        Me.cmdPNRWriteWithDocs.Size = New System.Drawing.Size(225, 35)
        Me.cmdPNRWriteWithDocs.TabIndex = 88
        Me.cmdPNRWriteWithDocs.Text = "Write to PNR with DOCS"
        Me.cmdPNRWriteWithDocs.UseVisualStyleBackColor = True
        '
        'lblSSRDocs
        '
        Me.lblSSRDocs.BackColor = System.Drawing.Color.Yellow
        Me.lblSSRDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSSRDocs.Location = New System.Drawing.Point(332, 419)
        Me.lblSSRDocs.Name = "lblSSRDocs"
        Me.lblSSRDocs.Size = New System.Drawing.Size(999, 29)
        Me.lblSSRDocs.TabIndex = 85
        Me.lblSSRDocs.Text = "SSR DOCS"
        Me.lblSSRDocs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvApis
        '
        Me.dgvApis.AllowUserToAddRows = False
        Me.dgvApis.AllowUserToDeleteRows = False
        Me.dgvApis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvApis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApis.Location = New System.Drawing.Point(12, 454)
        Me.dgvApis.Name = "dgvApis"
        Me.dgvApis.Size = New System.Drawing.Size(1319, 130)
        Me.dgvApis.TabIndex = 86
        '
        'cmdItineraryHelper
        '
        Me.cmdItineraryHelper.Location = New System.Drawing.Point(1206, 61)
        Me.cmdItineraryHelper.Name = "cmdItineraryHelper"
        Me.cmdItineraryHelper.Size = New System.Drawing.Size(125, 39)
        Me.cmdItineraryHelper.TabIndex = 94
        Me.cmdItineraryHelper.Text = "Itinerary Helper"
        Me.cmdItineraryHelper.UseVisualStyleBackColor = True
        '
        'cmdCostCentre
        '
        Me.cmdCostCentre.Location = New System.Drawing.Point(362, 12)
        Me.cmdCostCentre.Name = "cmdCostCentre"
        Me.cmdCostCentre.Size = New System.Drawing.Size(133, 35)
        Me.cmdCostCentre.TabIndex = 56
        Me.cmdCostCentre.Text = "Client Group Cost Centre Lookup"
        Me.cmdCostCentre.UseVisualStyleBackColor = True
        '
        'cmdPNRRead1APNR
        '
        Me.cmdPNRRead1APNR.Location = New System.Drawing.Point(12, 12)
        Me.cmdPNRRead1APNR.Name = "cmdPNRRead1APNR"
        Me.cmdPNRRead1APNR.Size = New System.Drawing.Size(157, 35)
        Me.cmdPNRRead1APNR.TabIndex = 54
        Me.cmdPNRRead1APNR.Text = "Read Amadeus PNR"
        Me.cmdPNRRead1APNR.UseVisualStyleBackColor = True
        '
        'cmdOneTimeVessel
        '
        Me.cmdOneTimeVessel.Location = New System.Drawing.Point(504, 12)
        Me.cmdOneTimeVessel.Name = "cmdOneTimeVessel"
        Me.cmdOneTimeVessel.Size = New System.Drawing.Size(133, 35)
        Me.cmdOneTimeVessel.TabIndex = 57
        Me.cmdOneTimeVessel.Text = "One time Vessel for PNR"
        Me.cmdOneTimeVessel.UseVisualStyleBackColor = True
        '
        'txtSubdepartment
        '
        Me.txtSubdepartment.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtSubdepartment.Location = New System.Drawing.Point(12, 219)
        Me.txtSubdepartment.Name = "txtSubdepartment"
        Me.txtSubdepartment.Size = New System.Drawing.Size(337, 20)
        Me.txtSubdepartment.TabIndex = 62
        '
        'txtCustomer
        '
        Me.txtCustomer.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(12, 74)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(337, 20)
        Me.txtCustomer.TabIndex = 59
        '
        'lblCostCentreHighlight
        '
        Me.lblCostCentreHighlight.BackColor = System.Drawing.Color.Pink
        Me.lblCostCentreHighlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCostCentreHighlight.Location = New System.Drawing.Point(992, 180)
        Me.lblCostCentreHighlight.Name = "lblCostCentreHighlight"
        Me.lblCostCentreHighlight.Size = New System.Drawing.Size(125, 27)
        Me.lblCostCentreHighlight.TabIndex = 78
        Me.lblCostCentreHighlight.Text = "Cost Centre"
        Me.lblCostCentreHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbCostCentre
        '
        Me.cmbCostCentre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCostCentre.FormattingEnabled = True
        Me.cmbCostCentre.Location = New System.Drawing.Point(1124, 183)
        Me.cmbCostCentre.Name = "cmbCostCentre"
        Me.cmbCostCentre.Size = New System.Drawing.Size(207, 21)
        Me.cmbCostCentre.TabIndex = 79
        '
        'cmdPNRWrite
        '
        Me.cmdPNRWrite.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNRWrite.Location = New System.Drawing.Point(643, 12)
        Me.cmdPNRWrite.Name = "cmdPNRWrite"
        Me.cmdPNRWrite.Size = New System.Drawing.Size(141, 35)
        Me.cmdPNRWrite.TabIndex = 87
        Me.cmdPNRWrite.Text = "Write to PNR"
        Me.cmdPNRWrite.UseVisualStyleBackColor = True
        '
        'lstCRM
        '
        Me.lstCRM.FormattingEnabled = True
        Me.lstCRM.Location = New System.Drawing.Point(12, 342)
        Me.lstCRM.Name = "lstCRM"
        Me.lstCRM.Size = New System.Drawing.Size(337, 69)
        Me.lstCRM.TabIndex = 66
        '
        'lblSegs
        '
        Me.lblSegs.BackColor = System.Drawing.Color.Coral
        Me.lblSegs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSegs.Location = New System.Drawing.Point(644, 87)
        Me.lblSegs.Name = "lblSegs"
        Me.lblSegs.Size = New System.Drawing.Size(337, 13)
        Me.lblSegs.TabIndex = 93
        Me.lblSegs.Text = "."
        Me.lblSegs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVessel
        '
        Me.txtVessel.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtVessel.Location = New System.Drawing.Point(362, 74)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(265, 20)
        Me.txtVessel.TabIndex = 68
        '
        'lblReasonForTravelHighLight
        '
        Me.lblReasonForTravelHighLight.BackColor = System.Drawing.Color.Pink
        Me.lblReasonForTravelHighLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblReasonForTravelHighLight.Location = New System.Drawing.Point(992, 146)
        Me.lblReasonForTravelHighLight.Name = "lblReasonForTravelHighLight"
        Me.lblReasonForTravelHighLight.Size = New System.Drawing.Size(125, 27)
        Me.lblReasonForTravelHighLight.TabIndex = 76
        Me.lblReasonForTravelHighLight.Text = "Reason for Travel"
        Me.lblReasonForTravelHighLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCRM
        '
        Me.txtCRM.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCRM.Location = New System.Drawing.Point(12, 321)
        Me.txtCRM.Name = "txtCRM"
        Me.txtCRM.Size = New System.Drawing.Size(337, 20)
        Me.txtCRM.TabIndex = 65
        '
        'lblPax
        '
        Me.lblPax.BackColor = System.Drawing.Color.Coral
        Me.lblPax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPax.Location = New System.Drawing.Point(644, 74)
        Me.lblPax.Name = "lblPax"
        Me.lblPax.Size = New System.Drawing.Size(337, 13)
        Me.lblPax.TabIndex = 92
        Me.lblPax.Text = "."
        Me.lblPax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstSubDepartments
        '
        Me.lstSubDepartments.FormattingEnabled = True
        Me.lstSubDepartments.Location = New System.Drawing.Point(12, 239)
        Me.lstSubDepartments.Name = "lstSubDepartments"
        Me.lstSubDepartments.Size = New System.Drawing.Size(337, 69)
        Me.lstSubDepartments.TabIndex = 63
        '
        'cmbReasonForTravel
        '
        Me.cmbReasonForTravel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReasonForTravel.FormattingEnabled = True
        Me.cmbReasonForTravel.Location = New System.Drawing.Point(1124, 149)
        Me.cmbReasonForTravel.Name = "cmbReasonForTravel"
        Me.cmbReasonForTravel.Size = New System.Drawing.Size(207, 21)
        Me.cmbReasonForTravel.TabIndex = 77
        '
        'lblSubDepartment
        '
        Me.lblSubDepartment.BackColor = System.Drawing.Color.Yellow
        Me.lblSubDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSubDepartment.Location = New System.Drawing.Point(12, 206)
        Me.lblSubDepartment.Name = "lblSubDepartment"
        Me.lblSubDepartment.Size = New System.Drawing.Size(337, 13)
        Me.lblSubDepartment.TabIndex = 61
        Me.lblSubDepartment.Text = "SubDepartment"
        Me.lblSubDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPNR
        '
        Me.lblPNR.BackColor = System.Drawing.Color.Coral
        Me.lblPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPNR.Location = New System.Drawing.Point(644, 61)
        Me.lblPNR.Name = "lblPNR"
        Me.lblPNR.Size = New System.Drawing.Size(337, 13)
        Me.lblPNR.TabIndex = 91
        Me.lblPNR.Text = "."
        Me.lblPNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRM
        '
        Me.lblCRM.BackColor = System.Drawing.Color.Yellow
        Me.lblCRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCRM.Location = New System.Drawing.Point(12, 308)
        Me.lblCRM.Name = "lblCRM"
        Me.lblCRM.Size = New System.Drawing.Size(337, 13)
        Me.lblCRM.TabIndex = 64
        Me.lblCRM.Text = "CRM - Invoicing Addresses"
        Me.lblCRM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDepartmentHighlight
        '
        Me.lblDepartmentHighlight.BackColor = System.Drawing.Color.Pink
        Me.lblDepartmentHighlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblDepartmentHighlight.Location = New System.Drawing.Point(644, 146)
        Me.lblDepartmentHighlight.Name = "lblDepartmentHighlight"
        Me.lblDepartmentHighlight.Size = New System.Drawing.Size(125, 27)
        Me.lblDepartmentHighlight.TabIndex = 72
        Me.lblDepartmentHighlight.Text = "Department"
        Me.lblDepartmentHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstVessels
        '
        Me.lstVessels.FormattingEnabled = True
        Me.lstVessels.Location = New System.Drawing.Point(362, 95)
        Me.lstVessels.Name = "lstVessels"
        Me.lstVessels.Size = New System.Drawing.Size(265, 316)
        Me.lstVessels.TabIndex = 69
        '
        'lblVessel
        '
        Me.lblVessel.BackColor = System.Drawing.Color.Yellow
        Me.lblVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblVessel.Location = New System.Drawing.Point(362, 53)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(265, 17)
        Me.lblVessel.TabIndex = 67
        Me.lblVessel.Text = "Vessel"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBookedByHighlight
        '
        Me.lblBookedByHighlight.BackColor = System.Drawing.Color.Pink
        Me.lblBookedByHighlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblBookedByHighlight.Location = New System.Drawing.Point(992, 112)
        Me.lblBookedByHighlight.Name = "lblBookedByHighlight"
        Me.lblBookedByHighlight.Size = New System.Drawing.Size(125, 27)
        Me.lblBookedByHighlight.TabIndex = 74
        Me.lblBookedByHighlight.Text = "Booked by"
        Me.lblBookedByHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstCustomers
        '
        Me.lstCustomers.FormattingEnabled = True
        Me.lstCustomers.Location = New System.Drawing.Point(12, 95)
        Me.lstCustomers.Name = "lstCustomers"
        Me.lstCustomers.Size = New System.Drawing.Size(337, 108)
        Me.lstCustomers.TabIndex = 60
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.Yellow
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(12, 53)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(337, 17)
        Me.lblCustomer.TabIndex = 58
        Me.lblCustomer.Text = "Customer"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblReference
        '
        Me.lblReference.BackColor = System.Drawing.Color.Cyan
        Me.lblReference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblReference.Location = New System.Drawing.Point(644, 112)
        Me.lblReference.Name = "lblReference"
        Me.lblReference.Size = New System.Drawing.Size(125, 27)
        Me.lblReference.TabIndex = 70
        Me.lblReference.Text = "Reference"
        Me.lblReference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbDepartment
        '
        Me.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(777, 149)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(207, 21)
        Me.cmbDepartment.TabIndex = 73
        '
        'lblAirlinePoints
        '
        Me.lblAirlinePoints.BackColor = System.Drawing.Color.Silver
        Me.lblAirlinePoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAirlinePoints.Location = New System.Drawing.Point(644, 210)
        Me.lblAirlinePoints.Name = "lblAirlinePoints"
        Me.lblAirlinePoints.Size = New System.Drawing.Size(687, 28)
        Me.lblAirlinePoints.TabIndex = 82
        Me.lblAirlinePoints.Text = "GDS Elements"
        Me.lblAirlinePoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbBookedby
        '
        Me.cmbBookedby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBookedby.FormattingEnabled = True
        Me.cmbBookedby.Location = New System.Drawing.Point(1124, 115)
        Me.cmbBookedby.Name = "cmbBookedby"
        Me.cmbBookedby.Size = New System.Drawing.Size(207, 21)
        Me.cmbBookedby.TabIndex = 75
        '
        'txtReference
        '
        Me.txtReference.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtReference.Location = New System.Drawing.Point(777, 115)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(207, 20)
        Me.txtReference.TabIndex = 71
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SSGDS, Me.SSPCC, Me.SSUser})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 604)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1472, 22)
        Me.StatusStrip1.TabIndex = 103
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SSGDS
        '
        Me.SSGDS.Name = "SSGDS"
        Me.SSGDS.Size = New System.Drawing.Size(29, 17)
        Me.SSGDS.Text = "GDS"
        '
        'SSPCC
        '
        Me.SSPCC.Name = "SSPCC"
        Me.SSPCC.Size = New System.Drawing.Size(30, 17)
        Me.SSPCC.Text = "PCC"
        '
        'SSUser
        '
        Me.SSUser.Name = "SSUser"
        Me.SSUser.Size = New System.Drawing.Size(30, 17)
        Me.SSUser.Text = "User"
        '
        'frm02Finisher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1472, 626)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblCTC)
        Me.Controls.Add(Me.cmdCTCForm)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstAirlineEntries)
        Me.Controls.Add(Me.txtTrId)
        Me.Controls.Add(Me.lblTRIDHighLight)
        Me.Controls.Add(Me.txtPNRApis)
        Me.Controls.Add(Me.cmdAPISEditPax)
        Me.Controls.Add(Me.cmdPNRRead1GPNR)
        Me.Controls.Add(Me.cmdPNROnlyDocs)
        Me.Controls.Add(Me.cmdPNRWriteWithDocs)
        Me.Controls.Add(Me.lblSSRDocs)
        Me.Controls.Add(Me.dgvApis)
        Me.Controls.Add(Me.cmdItineraryHelper)
        Me.Controls.Add(Me.cmdCostCentre)
        Me.Controls.Add(Me.cmdPNRRead1APNR)
        Me.Controls.Add(Me.cmdOneTimeVessel)
        Me.Controls.Add(Me.txtSubdepartment)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.lblCostCentreHighlight)
        Me.Controls.Add(Me.cmbCostCentre)
        Me.Controls.Add(Me.cmdPNRWrite)
        Me.Controls.Add(Me.lstCRM)
        Me.Controls.Add(Me.lblSegs)
        Me.Controls.Add(Me.txtVessel)
        Me.Controls.Add(Me.lblReasonForTravelHighLight)
        Me.Controls.Add(Me.txtCRM)
        Me.Controls.Add(Me.lblPax)
        Me.Controls.Add(Me.lstSubDepartments)
        Me.Controls.Add(Me.cmbReasonForTravel)
        Me.Controls.Add(Me.lblSubDepartment)
        Me.Controls.Add(Me.lblPNR)
        Me.Controls.Add(Me.lblCRM)
        Me.Controls.Add(Me.lblDepartmentHighlight)
        Me.Controls.Add(Me.lstVessels)
        Me.Controls.Add(Me.lblVessel)
        Me.Controls.Add(Me.lblBookedByHighlight)
        Me.Controls.Add(Me.lstCustomers)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.lblReference)
        Me.Controls.Add(Me.cmbDepartment)
        Me.Controls.Add(Me.lblAirlinePoints)
        Me.Controls.Add(Me.cmbBookedby)
        Me.Controls.Add(Me.txtReference)
        Me.Name = "frm02Finisher"
        Me.Text = "Finisher"
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCTC As Label
    Friend WithEvents cmdCTCForm As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lstAirlineEntries As CheckedListBox
    Friend WithEvents txtTrId As TextBox
    Friend WithEvents lblTRIDHighLight As Label
    Friend WithEvents txtPNRApis As TextBox
    Friend WithEvents cmdAPISEditPax As Button
    Friend WithEvents cmdPNRRead1GPNR As Button
    Friend WithEvents cmdPNROnlyDocs As Button
    Friend WithEvents cmdPNRWriteWithDocs As Button
    Friend WithEvents lblSSRDocs As Label
    Friend WithEvents dgvApis As DataGridView
    Friend WithEvents cmdItineraryHelper As Button
    Friend WithEvents cmdCostCentre As Button
    Friend WithEvents cmdPNRRead1APNR As Button
    Friend WithEvents cmdOneTimeVessel As Button
    Friend WithEvents txtSubdepartment As TextBox
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents lblCostCentreHighlight As Label
    Friend WithEvents cmbCostCentre As ComboBox
    Friend WithEvents cmdPNRWrite As Button
    Friend WithEvents lstCRM As ListBox
    Friend WithEvents lblSegs As Label
    Friend WithEvents txtVessel As TextBox
    Friend WithEvents lblReasonForTravelHighLight As Label
    Friend WithEvents txtCRM As TextBox
    Friend WithEvents lblPax As Label
    Friend WithEvents lstSubDepartments As ListBox
    Friend WithEvents cmbReasonForTravel As ComboBox
    Friend WithEvents lblSubDepartment As Label
    Friend WithEvents lblPNR As Label
    Friend WithEvents lblCRM As Label
    Friend WithEvents lblDepartmentHighlight As Label
    Friend WithEvents lstVessels As ListBox
    Friend WithEvents lblVessel As Label
    Friend WithEvents lblBookedByHighlight As Label
    Friend WithEvents lstCustomers As ListBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents lblReference As Label
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents lblAirlinePoints As Label
    Friend WithEvents cmbBookedby As ComboBox
    Friend WithEvents txtReference As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SSGDS As ToolStripStatusLabel
    Friend WithEvents SSPCC As ToolStripStatusLabel
    Friend WithEvents SSUser As ToolStripStatusLabel
End Class
