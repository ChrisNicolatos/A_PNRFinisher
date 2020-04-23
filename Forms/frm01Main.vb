Option Strict On
Option Explicit On
Public Class frm01Main

    Private pfrmFinisher As frm02Finisher
    Private pfrmItinerary As frm03Itinerary
    Private pfrmOSM As frm04OSM

    Private Sub CascadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub FinisherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinisherToolStripMenuItem.Click
        Try
            ShowFinisher()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ShowFinisher()
        If pfrmFinisher Is Nothing OrElse pfrmFinisher.IsDisposed Then
            pfrmFinisher = New frm02Finisher With {
            .MdiParent = Me,
            .WindowState = FormWindowState.Maximized}
        End If
        pfrmFinisher.Show()
        pfrmFinisher.BringToFront()

    End Sub
    Private Sub ItineraryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItineraryToolStripMenuItem.Click
        If pfrmItinerary Is Nothing OrElse pfrmItinerary.IsDisposed Then
            pfrmItinerary = New frm03Itinerary With {
            .MdiParent = Me,
            .WindowState = FormWindowState.Maximized}
        End If
        pfrmItinerary.Show()
        pfrmItinerary.BringToFront()
    End Sub

    Private Sub OSMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OSMToolStripMenuItem.Click
        If pfrmOSM Is Nothing OrElse pfrmOSM.IsDisposed Then
            pfrmOSM = New frm04OSM With {
            .MdiParent = Me,
            .WindowState = FormWindowState.Maximized}
        End If
        pfrmOSM.Show()
        pfrmOSM.BringToFront()
    End Sub

    Private Sub frmFormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        SSVersion.Text = VersionText
        ShowFinisher()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        Try
            Dim pFrm As New frmShowOptions
            pFrm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        Try
            Dim pfrmAdmin As New frmUser(EnumGDSCode.Amadeus, "ATHG42100", "9044CN")
            MessageBox.Show(pfrmAdmin.ShowDialog(Me).ToString)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PriceOptimizerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceOptimizerToolStripMenuItem.Click
        ShowPriceOptimiser(Me, True)
    End Sub
End Class