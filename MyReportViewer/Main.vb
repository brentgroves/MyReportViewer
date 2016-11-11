﻿Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms

Public Class Main
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Dim cryRpt As New CrystalReport1
        ' CrystalReportViewer1.ReportSource = cryRpt
        ' CrystalReportViewer1.Refresh()
        'https://msdn.microsoft.com/en-us/library/ms225594(v=vs.80).aspx
        'https://msdn.microsoft.com/en-gb/library/ms227604(v=vs.80).aspx

        TreeView1.Nodes.Clear()
        'Creating the root node
        Dim root = New TreeNode("Busche Reporter")
        TreeView1.Nodes.Add(root)

        Dim engineering = New TreeNode("Engineering")
        engineering.Name = "Engineering"

        '     TreeView1.Nodes(0).Nodes.Add(engineering)
        TreeView1.Nodes(0).Nodes.Add(engineering)

        Dim mydir As String
        mydir = "\\buschesv2\public\report Files\Engineering"
        '       TreeView1.SelectedNode = engineering


        For Each foundFile As String In My.Computer.FileSystem.GetFiles(mydir)
            Dim rpt = New TreeNode(System.IO.Path.GetFileNameWithoutExtension(foundFile))
            rpt.Name = foundFile
            TreeView1.Nodes(0).Nodes(0).Nodes.Add(rpt)
            '            TreeView1.SelectedNode.Nodes.Add(rpt)
        Next


    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        '   reportDocument1.Load("\\buschesv2\public\report Files\Engineering\Tool Cost Summary by Plant.rpt")
        '      reportDocument1.FileName = "\\buschesv2\public\report Files\Engineering\Tool Cost Summary by Plant.rpt"
        '        CrystalReportViewer1.ReportSource = reportDocument1
        '       CrystalReportViewer1.Refresh()
        If (e.Node.Parent IsNot Nothing) Then

            If (e.Node.Parent.Name = "Engineering" Or
               e.Node.Parent.Name = "Production" Or
               e.Node.Parent.Name = "Purchasing" Or
               e.Node.Parent.Name = "Quality" Or
               e.Node.Parent.Name = "Sales") Then
                Dim strFileName As String
                strFileName = ""
                strFileName = e.Node.Name

                reportDocument1.Load(strFileName)

                CrystalReportViewer1.ReportSource = reportDocument1
                CrystalReportViewer1.Refresh()

            End If
        End If

    End Sub
End Class
