﻿Public Class Form1

    'main components
    Dim Pan As Panel
    Dim AddG, AddH, Solve As Button

    'main variables 
    Dim NodesNum As Integer
    Dim Nodes(50) As List(Of Integer)
    Dim FuncsIDs(50) As List(Of Integer)
    Dim FuncsNames As New List(Of String)

    'for G & H Functions (forward and feedback)
    Dim counterNew As Integer = 0
    Dim counterG As Integer = 0
    Dim firstG, secondG, IDG As New List(Of Integer)
    Dim counterH As Integer = 1
    Dim firstH, secondH, IDH As New List(Of Integer)

    'design variables 
    Dim nodes_color As Color = Color.Yellow
    Dim funcsG_color As Color = Color.Red
    Dim funcsH_color As Color = Color.Blue
    Dim panelback_color As Color = Color.White
    Dim h_factor As Integer = 20
    Dim H_color As Color = Color.Blue
    Dim g_factor As Integer = 20
    Dim G_color As Color = Color.Red

    ' System variables 
    Dim Loops_Nodes As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim Loops_Funcs As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim Loops_Nodes_Filtered As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim Loops_Funcs_Filtered As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim Filtered As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim Path_Nodes As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim Path_Funcs As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim Path_Delta As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim non_touching2 As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim non_touching3 As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim non_touching4 As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Dim non_touching5 As List(Of List(Of Integer)) = New List(Of List(Of Integer))

    'Report data 
    ' Global variables : full_report & transfer_function
    Dim rprt As String
    Dim nom As String
    Dim dom As String

    Private Sub report()
        dom = ""
        nom = ""
        rprt = "System Full Report: " & vbNewLine
        find_Paths_Delta()
        find_non_touching()
        rprt += Path_Nodes.Count & " Foward Paths: " & vbNewLine
        For i = 0 To Path_Nodes.Count - 1
            rprt += "M" & i + 1 & ": "
            For Each k As Integer In Path_Funcs(i)
                rprt += "(" & FuncsNames(k) & ")"
            Next
            rprt += vbNewLine

        Next

        rprt += Loops_Funcs_Filtered.Count & " Indivisual Loops: " & vbNewLine

        For i = 0 To Loops_Funcs_Filtered.Count - 1
            rprt += "L" & i + 1 & ": "
            For Each k As Integer In Loops_Funcs_Filtered(i)
                rprt += "(" & FuncsNames(k) & ")"
            Next
            rprt += vbNewLine
        Next

        Dim tempStr As String = "1 "
        nom = "1 "
        rprt += non_touching2.Count & " Two Non Touching Loops: " & vbNewLine

        For i = 0 To non_touching2.Count - 1
            rprt += i + 1 & ": "
            If i = 0 Then
                tempStr += "-[ "
                nom += "-[ "
            End If
            For Each k As Integer In non_touching2(i)
                rprt += "(L" & k + 1 & ")"
                tempStr += "(L" & k + 1 & ")"
                nom += "("
                For Each z As Integer In Loops_Funcs_Filtered(k)
                    nom += "(" & FuncsNames(z) & ")"
                Next
                nom += ")"
            Next
            If i = non_touching2.Count - 1 Then
                tempStr += "] "
                nom += "]"
            Else
                tempStr += "+"
                nom += "+"
            End If
            rprt += vbNewLine
        Next

        rprt += non_touching3.Count & " Three Non Touching Loops: " & vbNewLine

        For i = 0 To non_touching3.Count - 1
            rprt += i + 1 & ": "
            If i = 0 Then
                tempStr += "+[ "
                nom += "+[ "
            End If
            For Each k As Integer In non_touching3(i)
                rprt += "(L" & k + 1 & ")"
                tempStr += "(L" & k + 1 & ")"
                nom += "("
                For Each z As Integer In Loops_Funcs_Filtered(k)
                    nom += "(" & FuncsNames(z) & ")"
                Next
                nom += ")"
            Next
            If i = non_touching3.Count - 1 Then
                tempStr += "] "
                nom += "]"
            Else
                tempStr += "+"
                nom += "+"
            End If
            rprt += vbNewLine
        Next

        rprt += non_touching4.Count & " Four Non Touching Loops: " & vbNewLine

        For i = 0 To non_touching4.Count - 1
            rprt += i + 1 & ": "
            If i = 0 Then
                tempStr += "-[ "
                nom += "-[ "
            End If
            For Each k As Integer In non_touching4(i)
                rprt += "(L" & k + 1 & ")"
                tempStr += "(L" & k + 1 & ")"
                nom += "("
                For Each z As Integer In Loops_Funcs_Filtered(k)
                    nom += "(" & FuncsNames(z) & ")"
                Next
                nom += ")"
            Next
            If i = non_touching4.Count - 1 Then
                tempStr += "] "
                nom += "]"
            Else
                tempStr += "+"
                nom += "+"
            End If
            rprt += vbNewLine
        Next

        rprt += non_touching5.Count & " Five Non Touching Loops: " & vbNewLine

        For i = 0 To non_touching5.Count - 1
            rprt += i + 1 & ": "
            If i = 0 Then
                tempStr += "+[ "
                nom += "+[ "
            End If
            For Each k As Integer In non_touching5(i)
                rprt += "(L" & k + 1 & ")"
                tempStr += "(L" & k + 1 & ")"
                nom += "("
                For Each z As Integer In Loops_Funcs_Filtered(k)
                    nom += "(" & FuncsNames(z) & ")"
                Next
                nom += ")"
            Next
            If i = non_touching5.Count - 1 Then
                tempStr += "] "
                nom += "]"
            Else
                tempStr += "+"
                nom += "+"
            End If
            rprt += vbNewLine
        Next

        rprt += "Forward Paths' Deltas: " & vbNewLine

        dom += "[ "
        For i = 0 To Path_Delta.Count - 1
            rprt += "Δ" & i + 1 & ": 1"

            dom += "("
            For Each k As Integer In Path_Funcs(i)
                dom += FuncsNames(k)
            Next
            dom += ")("

            If Path_Delta(i).Count > 0 Then
                rprt += " - ["
                For k = 0 To Path_Delta(i).Count - 1
                    rprt += "L" & Path_Delta(i)(k) + 1

                    For Each z As Integer In Loops_Funcs_Filtered(Path_Delta(i)(k))
                        dom += "(" & FuncsNames(z) & ")"
                    Next


                    If k <> Path_Delta(i).Count - 1 Then
                        rprt += "+"
                        dom += " + "
                    End If

                Next


                rprt += " ]"
            End If

            dom += ")"

            If i <> Path_Delta.Count - 1 Then
                dom += " + "
            End If

            rprt += vbNewLine
        Next
        dom += "]"

        rprt += "System determinant:" & vbNewLine & "Δ = " & tempStr


        full_report = rprt
        transfer_function = dom & vbNewLine & "____________________________" & vbNewLine & nom


    End Sub

    Private Sub find_Paths_Delta()
        Path_Delta.Clear()
        find_loops()
        find_forawrd_paths()

        For i = 0 To Path_Nodes.Count - 1
            Dim templist As List(Of Integer) = New List(Of Integer)
            For j = 0 To Loops_Nodes_Filtered.Count - 1
                If check_touch_loops(Path_Nodes(i), Loops_Nodes_Filtered(j)) = False Then
                    templist.Add(j)
                End If
            Next
            Dim templist2 As List(Of Integer) = New List(Of Integer)
            copy_lists(templist2, templist)
            Path_Delta.Add(templist2)

            templist.Clear()
        Next

    End Sub


    Private Sub find_non_touching()
        non_touching2.Clear()
        non_touching3.Clear()
        non_touching4.Clear()
        non_touching5.Clear()

        find_loops()



        For i = 0 To Loops_Nodes_Filtered.Count - 1
            For j = i + 1 To Loops_Nodes_Filtered.Count - 1
                If check_touch_loops(Loops_Nodes_Filtered(i), Loops_Nodes_Filtered(j)) = False Then
                    Dim templist1 As New List(Of Integer)
                    templist1.Clear()
                    templist1.Add(i)
                    templist1.Add(j)

                    non_touching2.Add(templist1)


                    For k = j + 1 To Loops_Nodes_Filtered.Count - 1
                        If check_touch_loops(Loops_Nodes_Filtered(i), Loops_Nodes_Filtered(k)) = False And check_touch_loops(Loops_Nodes_Filtered(j), Loops_Nodes_Filtered(k)) = False Then
                            Dim templist2 As New List(Of Integer)
                            templist2.Clear()

                            templist2.Add(i)
                            templist2.Add(j)
                            templist2.Add(k)

                            non_touching3.Add(templist2)

                            For w = k + 1 To Loops_Nodes_Filtered.Count - 1
                                If check_touch_loops(Loops_Nodes_Filtered(i), Loops_Nodes_Filtered(w)) = False And check_touch_loops(Loops_Nodes_Filtered(j), Loops_Nodes_Filtered(w)) = False And check_touch_loops(Loops_Nodes_Filtered(k), Loops_Nodes_Filtered(w)) = False Then
                                    Dim templist3 As New List(Of Integer)
                                    templist3.Clear()

                                    templist3.Add(i)
                                    templist3.Add(j)
                                    templist3.Add(k)
                                    templist3.Add(w)

                                    non_touching4.Add(templist3)

                                    For e = w + 1 To Loops_Nodes_Filtered.Count - 1

                                        If check_touch_loops(Loops_Nodes_Filtered(i), Loops_Nodes_Filtered(e)) = False And check_touch_loops(Loops_Nodes_Filtered(j), Loops_Nodes_Filtered(e)) = False And check_touch_loops(Loops_Nodes_Filtered(k), Loops_Nodes_Filtered(e)) = False And check_touch_loops(Loops_Nodes_Filtered(w), Loops_Nodes_Filtered(e)) = False Then
                                            Dim templist4 As New List(Of Integer)
                                            templist4.Clear()

                                            templist4.Add(i)
                                            templist4.Add(j)
                                            templist4.Add(k)
                                            templist4.Add(w)
                                            templist4.Add(e)

                                            non_touching5.Add(templist4)
                                        End If

                                    Next

                                End If
                            Next

                        End If
                    Next

                End If


            Next

        Next



    End Sub

    Private Sub clear_all()
        ' clear components 
        Controls.Remove(Pan)
        'main varibales clear
        NodesNum = -1
        Array.Clear(Nodes, 0, Nodes.Length)
        Array.Clear(FuncsIDs, 0, FuncsIDs.Length)
        FuncsNames.Clear()
        ' G& H variables clear
        counterNew = 0
        counterG = 0
        firstG.Clear()
        secondG.Clear()
        IDG.Clear()
        counterH = 0
        firstH.Clear()
        secondH.Clear()
        IDH.Clear()
        ' no need to clear design variables
        ' system variables clear
        Loops_Nodes.Clear()
        Loops_Funcs.Clear()
        Loops_Funcs_Filtered.Clear()
        Loops_Nodes_Filtered.Clear()
        Filtered.Clear()
        Path_Funcs.Clear()
        Path_Nodes.Clear()
        Path_Delta.Clear()
        non_touching2.Clear()
        non_touching3.Clear()
        non_touching4.Clear()
        non_touching5.Clear()
        ' report data clear
        rprt = ""
        nom = ""
        dom = ""
    End Sub

    Private Sub NewGraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGraphToolStripMenuItem.Click
        clear_all()
        'ask user for number of nodes
        NodesNum = Val(InputBox("Please enter the number of nodes: "))

        Create_Panel()
        Connect_Nodes()
        update_Drawing()

    End Sub




    Private Sub Connect_Nodes()
        FuncsNames.Add("-")
        Nodes(0) = New List(Of Integer)
        For i = 1 To NodesNum - 1
            Dim funcnametemp As String = "G" & i - 1
            Nodes(i) = New List(Of Integer)
            FuncsIDs(i) = New List(Of Integer)
            Nodes(i).Add(i + 1)
            FuncsIDs(i).Add(i)
            FuncsNames.Add(funcnametemp)
        Next
        Nodes(NodesNum) = New List(Of Integer)
        FuncsIDs(NodesNum) = New List(Of Integer)
    End Sub
    Private Sub Draw_Nodes()

        Dim FlowLO As New FlowLayoutPanel
        FlowLO.Name = "FlowLO"
        FlowLO.Size = New Size(FlowLO.AutoSizeMode, 20)
        FlowLO.AutoSize = True
        FlowLO.AutoSizeMode = AutoSizeMode.GrowOnly
        FlowLO.Top = 200
        FlowLO.Left = 10
        FlowLO.BackColor = panelback_color
        Pan.Controls.Add(FlowLO)


        For i As Integer = 1 To NodesNum
            Dim nodeLabel As New Label
            nodeLabel.Text = "X" & i
            nodeLabel.Name = "X" & i
            nodeLabel.BackColor = nodes_color
            nodeLabel.Size = New Size(40, 23)
            nodeLabel.Margin = New Padding(0, 3, 0, 3)
            FlowLO.Controls.Add(nodeLabel)



            If (NodesNum > i) Then

                Dim funcnametemp As String = FuncsNames(i)

                Dim funclabel As New Label
                funclabel.Name = funcnametemp
                funclabel.Size = New Size(30, 15)
                funclabel.Text = funcnametemp
                funclabel.ForeColor = Color.White
                funclabel.BackColor = G_color
                funclabel.Margin = New Padding(0, 7, 0, 7)
                AddHandler funclabel.Click, AddressOf funcLabel_Click
                FlowLO.Controls.Add(funclabel)

            End If
        Next




    End Sub

    Private Sub funcLabel_Click(sender As Object, e As EventArgs)

        ' nothing
    End Sub





    Private Sub Create_Panel()
        Pan = New Panel
        Pan.Name = "Panel"
        Pan.Left = 15
        Pan.Top = 50
        Pan.Height = 400
        Pan.Width = 800
        Pan.BackColor = panelback_color
        Pan.AutoScroll = True
        Controls.Add(Pan)

        AddG = New Button
        AddG.Name = "AddG"
        AddG.Text = "Add G"
        AddG.Left = 15
        AddG.Top = 15
        AddG.Height = 20
        AddG.Width = 50
        Pan.Controls.Add(AddG)
        AddHandler AddG.Click, AddressOf AddG_Click


        AddH = New Button
        AddH.Name = "AddH"
        AddH.Text = "Add H"
        AddH.Left = 75
        AddH.Top = 15
        AddH.Height = 20
        AddH.Width = 50
        Pan.Controls.Add(AddH)
        AddHandler AddH.Click, AddressOf AddH_Click

        Solve = New Button
        Solve.Name = "Solve"
        Solve.Text = "Solve"
        Solve.Left = 135
        Solve.Top = 15
        Solve.Height = 20
        Solve.Width = 50
        Pan.Controls.Add(Solve)
        AddHandler Solve.Click, AddressOf Solve_Click



    End Sub



    Private Sub AddG_Click(sender As Object, e As EventArgs)
        Dim f As Integer = Val(InputBox("enter the start point of G"))
        Dim s As Integer = Val(InputBox("enter the end point of G"))
        Dim GName As String = InputBox("enter the name of new G", "Add G", "G" & NodesNum - 1 + counterG)
        If f > s Then
            MsgBox("first point must be before the end point")
        Else
            connectNewG(f, s, GName)
            update_Drawing()

        End If
    End Sub


    Private Sub connectNewG(ByVal first As Integer, ByVal second As Integer, ByVal name As String)
        firstG.Add(first)
        secondG.Add(second)
        IDG.Add(NodesNum + counterNew)

        Nodes(first).Add(second)
        FuncsIDs(first).Add(NodesNum + counterNew)
        FuncsNames.Add(name)

        counterNew += 1
        counterG += 1
    End Sub


    Private Sub connectNewH(ByVal first As Integer, ByVal second As Integer, ByVal name As String)
        firstH.Add(first)
        secondH.Add(second)
        IDH.Add(NodesNum + counterNew)

        Nodes(first).Add(second)
        FuncsIDs(first).Add(NodesNum + counterNew)
        FuncsNames.Add(name)

        counterNew += 1
        counterH += 1
    End Sub



    Private Sub Draw_G()



        For i = 0 To IDG.Count - 1

            Dim g_disp As Integer = i * g_factor

            Dim first As Integer = firstG(i)
            Dim second As Integer = secondG(i)

            Dim k As New PictureBox
            k.BorderStyle = BorderStyle.None
            k.Size = New Size(5, 20 + g_disp)
            k.BackColor = G_color
            k.Left = 30 + (first - 1) * 70
            k.Top = 180 - g_disp
            Pan.Controls.Add(k)


            Dim k2 As New PictureBox
            k2.BorderStyle = BorderStyle.None
            k2.Size = New Size(5, 20 + g_disp)
            k2.BackColor = G_color
            k2.Left = 30 + (second - 1) * 70
            k2.Top = 180 - g_disp
            Pan.Controls.Add(k2)

            Dim k3 As New PictureBox
            k3.BorderStyle = BorderStyle.None
            k3.Size = New Size((second - first) * 70, 5)
            k3.BackColor = G_color
            k3.Left = 30 + (first - 1) * 70
            k3.Top = 180 - g_disp
            Pan.Controls.Add(k3)

            Dim funcnametemp As String = FuncsNames(IDG(i))
            Dim pic As New Label
            pic.Name = funcnametemp
            pic.Size = New Size(40, 15)
            pic.Text = funcnametemp
            pic.ForeColor = Color.White
            pic.BackColor = G_color
            pic.Left = (k.Location.X + k2.Location.X) / 2 - 20
            pic.Top = 175 - g_disp
            Pan.Controls.Add(pic)
            pic.BringToFront()
        Next




    End Sub

    Private Sub ChangeBackcolorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeBackcolorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        panelback_color = ColorDialog1.Color
        update_Drawing()
    End Sub

    Private Sub ListFunctionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListFunctionsToolStripMenuItem.Click
        Dim devstr As String = ""
        For i = 0 To FuncsNames.Count - 1
            devstr += FuncsNames(i) & vbNewLine
        Next
        MsgBox(devstr)
    End Sub


    Private Sub ListConnectionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListConnectionsToolStripMenuItem.Click
        Dim devstr As String = ""
        For i = 1 To NodesNum
            devstr += "Node " & i & ": "
            For j = 0 To FuncsIDs(i).Count - 1
                devstr += FuncsNames(FuncsIDs(i)(j)) & ">" & Nodes(i)(j) & " "
            Next
            devstr += vbNewLine
        Next
        MsgBox(devstr)
    End Sub




    Private Sub Draw_H()

        For i = 0 To IDH.Count - 1
            Dim h_disp As Integer = h_factor * i

            Dim first As Integer = firstH(i)
            Dim second As Integer = secondH(i)

            Dim k As New PictureBox
            k.BorderStyle = BorderStyle.None
            k.Size = New Size(5, 20 + h_disp)
            k.BackColor = H_color
            k.Left = 30 + (first - 1) * 70
            k.Top = 220
            Pan.Controls.Add(k)


            Dim k2 As New PictureBox
            k2.BorderStyle = BorderStyle.None
            k2.Size = New Size(5, 20 + h_disp)
            k2.BackColor = H_color
            k2.Left = 30 + (second - 1) * 70
            k2.Top = 220
            Pan.Controls.Add(k2)

            Dim k3 As New PictureBox
            k3.BorderStyle = BorderStyle.None
            k3.Size = New Size((first - second) * 70 + 5, 5)
            k3.BackColor = H_color
            k3.Left = 30 + (second - 1) * 70
            k3.Top = 240 + h_disp
            Pan.Controls.Add(k3)

            Dim funcnametemp As String = FuncsNames(IDH(i))
            Dim pic As New Label
            pic.Name = funcnametemp
            pic.Size = New Size(40, 15)
            pic.Text = funcnametemp
            pic.ForeColor = Color.White
            pic.BackColor = H_color
            pic.Left = (k.Location.X + k2.Location.X) / 2 - 20
            pic.Top = 235 + h_disp
            Pan.Controls.Add(pic)
            pic.BringToFront()



        Next










    End Sub

    Private Sub ListLoopsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListLoopsToolStripMenuItem.Click
        find_loops()
        MsgBox("Numbef of Loops :" & Loops_Funcs_Filtered.Count)
        For i = 0 To Loops_Funcs_Filtered.Count - 1
            show_funcs(Loops_Funcs_Filtered(i))
        Next
    End Sub


    Private Sub find_loops()
        Loops_Funcs.Clear()
        Loops_Nodes.Clear()
        Loops_Funcs_Filtered.Clear()
        Loops_Nodes_Filtered.Clear()
        Filtered.Clear()

        For i = 1 To NodesNum
            BFS(i)
        Next

        Dim flag As Boolean = False
        For i = 0 To Loops_Funcs.Count - 1


            flag = False
            Dim lp As List(Of Integer) = New List(Of Integer)
            copy_lists(lp, Loops_Funcs(i))
            lp.Sort()

            For j = 0 To Filtered.Count - 1
                If check_touch_2(lp, Filtered(j)) Then
                    flag = True
                End If
            Next

            If flag = False Then
                Loops_Funcs_Filtered.Add(Loops_Funcs(i))
                Loops_Nodes_Filtered.Add(Loops_Nodes(i))
                Filtered.Add(lp)
            End If

        Next


    End Sub




    Private Sub update_Drawing()
        Me.Controls.Remove(Pan)
        Create_Panel()
        Draw_Nodes()
        Draw_G()
        Draw_H()
    End Sub

    Private Sub AddH_Click(sender As Object, e As EventArgs)
        Dim f As Integer = Val(InputBox("enter the start point of H"))
        Dim s As Integer = Val(InputBox("enter the end point of H"))
        Dim HName As String = InputBox("enter the name of new H", "Add H", "-H" & counterH + 1)
        If f < s Then
            MsgBox("end point must be before the start point")
        Else
            connectNewH(f, s, HName)
            update_Drawing()

        End If
    End Sub
    Private Sub Solve_Click(sender As Object, e As EventArgs)
        report()
        Form2.Show()
    End Sub






    Private Sub Case1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Case1ToolStripMenuItem.Click
        clear_all()
        NodesNum = 8

        Create_Panel()
        Connect_Nodes()

        connectNewG(4, 7, "G7")
        connectNewG(6, 8, "G8")

        connectNewH(8, 6, "-H1")
        connectNewH(7, 3, "-H2")
        connectNewH(8, 2, "-H3")
        connectNewH(6, 5, "-H4")


        update_Drawing()
    End Sub



    Private Sub Case2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Case2ToolStripMenuItem.Click
        clear_all()
        NodesNum = 8

        Create_Panel()
        Connect_Nodes()

        connectNewG(1, 7, "G8")
        connectNewH(7, 3, "-H1")
        connectNewH(4, 1, "-H2")
        update_Drawing()
    End Sub

    Private Sub Case3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Case3ToolStripMenuItem.Click
        clear_all()
        NodesNum = 7

        Create_Panel()
        Connect_Nodes()


        connectNewH(6, 4, "H1")
        connectNewH(6, 2, "-H3")
        connectNewH(5, 3, "-H2")

        update_Drawing()
    End Sub

    Private Sub Case4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Case4ToolStripMenuItem.Click
        clear_all()
        NodesNum = 6

        Create_Panel()
        Connect_Nodes()

        connectNewG(3, 6, "G5")


        connectNewH(3, 2, "-H1")
        connectNewH(5, 4, "-H2")
        connectNewH(5, 2, "-H3")
        connectNewH(6, 6, "-H4")


        update_Drawing()
    End Sub

    Private Sub BFS(ByVal b As Integer)



        Dim qu As Queue(Of Integer) = New Queue(Of Integer)()
        Dim nodespath As Queue(Of List(Of Integer)) = New Queue(Of List(Of Integer))
        Dim funcspath As Queue(Of List(Of Integer)) = New Queue(Of List(Of Integer))

        Dim src As Integer

        src = b
        qu.Enqueue(src)
        Dim temp01 As List(Of Integer) = New List(Of Integer)
        temp01.Add(src)
        nodespath.Enqueue(temp01)
        Dim temp02 As List(Of Integer) = New List(Of Integer)
        temp02.Add(-1)
        funcspath.Enqueue(temp02)

        Dim ft As Boolean = True

        While (qu.Count > 0)
            Dim temp1 As List(Of Integer) = New List(Of Integer)
            Dim temp2 As List(Of Integer) = New List(Of Integer)

            src = qu.First
            copy_lists(temp1, nodespath.First)
            copy_lists(temp2, funcspath.First)

            qu.Dequeue()
            nodespath.Dequeue()
            funcspath.Dequeue()


            For i = 0 To Nodes(src).Count - 1
                Dim cNode As Integer = Nodes(src)(i)
                Dim cFunc As Integer = FuncsIDs(src)(i)


                If cNode = b Then


                    If temp2(0) <> -1 Then
                        MsgBox("Oh!")
                    End If

                    Dim temp5 As List(Of Integer) = New List(Of Integer)
                    Dim temp6 As List(Of Integer) = New List(Of Integer)

                    copy_lists(temp5, temp1)
                    copy_lists(temp6, temp2)

                    temp6.Remove(-1)
                    temp6.Add(cFunc)
                    Loops_Nodes.Add(temp5)
                    Loops_Funcs.Add(temp6)


                Else

                    If check_touch(cNode, temp1) = False And check_touch(cFunc, temp2) = False Then

                        Dim temp3 As List(Of Integer) = New List(Of Integer)
                        Dim temp4 As List(Of Integer) = New List(Of Integer)

                        copy_lists(temp3, temp1)
                        copy_lists(temp4, temp2)



                        temp3.Add(cNode)
                        temp4.Add(cFunc)

                        qu.Enqueue(cNode)
                        nodespath.Enqueue(temp3)
                        funcspath.Enqueue(temp4)

                    End If
                End If
            Next

        End While


    End Sub


    Private Sub show_list(ByVal lst As List(Of Integer))
        Dim s As String = ""
        For k = 0 To lst.Count - 1
            s += lst(k) & ":"
        Next
        MsgBox(s)
    End Sub
    Private Sub show_funcs(ByVal lst As List(Of Integer))
        Dim s As String = ""
        For k = 0 To lst.Count - 1
            s += FuncsNames(lst(k)) & ":"
        Next
        MsgBox(s)
    End Sub

    Private Sub ListPathDeltasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListPathDeltasToolStripMenuItem.Click
        find_Paths_Delta()
        For i = 0 To Path_Delta.Count - 1
            show_list(Path_Delta(i))
        Next
    End Sub

    Private Sub Case5ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Case5ToolStripMenuItem.Click
        clear_all()
        NodesNum = 9

        Create_Panel()
        Connect_Nodes()

        connectNewG(2, 8, "G7")


        connectNewH(4, 3, "-H1")
        connectNewH(6, 5, "-H2")


        update_Drawing()
    End Sub

    Private Sub ShowNonTouchingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowNonTouchingToolStripMenuItem.Click
        find_non_touching()
        MsgBox("2 Non touching loops: " & non_touching2.Count)
        For i = 0 To non_touching2.Count - 1
            show_list(non_touching2(i))
        Next

        MsgBox("3 Non touching loops: " & non_touching3.Count)
        For i = 0 To non_touching3.Count - 1
            show_list(non_touching3(i))
        Next

        MsgBox("4 Non touching loops: " & non_touching4.Count)
        For i = 0 To non_touching4.Count - 1
            show_list(non_touching4(i))
        Next

        MsgBox("5 Non touching loops: " & non_touching5.Count)
        For i = 0 To non_touching5.Count - 1
            show_list(non_touching5(i))
        Next
    End Sub

    Private Sub ReportSystemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportSystemToolStripMenuItem.Click
        report()
        MsgBox(rprt)
    End Sub

    Private Sub Case6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Case6ToolStripMenuItem.Click
        clear_all()
        NodesNum = 10

        Create_Panel()
        Connect_Nodes()

        For i = 1 To 9 Step 2
            connectNewH(i + 1, i, "-H")
        Next

        update_Drawing()
    End Sub


    Private Sub ChangeNodesColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeNodesColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        nodes_color = ColorDialog1.Color
        update_Drawing()
    End Sub

    Private Sub ChangeGColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeGColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        G_color = ColorDialog1.Color
        update_Drawing()
    End Sub

    Private Sub ChangeHColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeHColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        H_color = ColorDialog1.Color
        update_Drawing()
    End Sub


    Private Sub ListForwardPathsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListForwardPathsToolStripMenuItem.Click

        find_forawrd_paths()
        MsgBox("Number of Forward Paths: " & Path_Funcs.Count)
        For i = 0 To Path_Funcs.Count - 1
            show_funcs(Path_Funcs(i))
        Next
    End Sub

    Private Sub copy_lists(ByRef lst1 As List(Of Integer), ByVal lst2 As List(Of Integer))
        lst1.Clear()
        lst1.AddRange(lst2)
    End Sub

    Function check_touch(ByVal x As Integer, ByVal lst As List(Of Integer)) As Boolean
        Dim flag As Boolean = False
        For i = 0 To lst.Count - 1
            If x = lst(i) Then
                flag = True
            End If
        Next
        check_touch = flag
    End Function

    Function check_touch_2(ByVal lst1 As List(Of Integer), ByVal lst2 As List(Of Integer)) As Boolean
        Dim flag As Boolean = True
        If lst1.Count = lst2.Count Then
            For i = 0 To lst1.Count - 1
                If lst1(i) <> lst2(i) Then
                    flag = False
                End If
            Next
        Else
            flag = False
        End If
        check_touch_2 = flag
    End Function

    Function check_touch_loops(ByVal lst1 As List(Of Integer), ByVal lst2 As List(Of Integer)) As Boolean
        Dim flag As Boolean = False

        For i = 0 To lst1.Count - 1
            For j = 0 To lst2.Count - 1
                If lst1(i) = lst2(j) Then
                    flag = True
                End If
            Next
        Next

        check_touch_loops = flag
    End Function


    Private Sub find_forawrd_paths()

        Path_Funcs.Clear()
        Path_Nodes.Clear()

        Dim qu As Queue(Of Integer) = New Queue(Of Integer)()
        Dim nodespath As Queue(Of List(Of Integer)) = New Queue(Of List(Of Integer))
        Dim funcspath As Queue(Of List(Of Integer)) = New Queue(Of List(Of Integer))

        Dim src, tar As Integer

        src = 1
        tar = NodesNum

        qu.Enqueue(src)
        Dim temp01 As List(Of Integer) = New List(Of Integer)
        temp01.Add(src)
        nodespath.Enqueue(temp01)
        Dim temp02 As List(Of Integer) = New List(Of Integer)
        temp02.Add(-1)
        funcspath.Enqueue(temp02)

        Dim ft As Boolean = True

        While (qu.Count > 0)
            Dim temp1 As List(Of Integer) = New List(Of Integer)
            Dim temp2 As List(Of Integer) = New List(Of Integer)

            src = qu.First
            copy_lists(temp1, nodespath.First)
            copy_lists(temp2, funcspath.First)

            qu.Dequeue()
            nodespath.Dequeue()
            funcspath.Dequeue()


            For i = 0 To Nodes(src).Count - 1
                Dim cNode As Integer = Nodes(src)(i)
                Dim cFunc As Integer = FuncsIDs(src)(i)


                If cNode = tar Then

                    If temp2(0) <> -1 Then
                        MsgBox("Oh!")
                    End If

                    Dim temp5 As List(Of Integer) = New List(Of Integer)
                    Dim temp6 As List(Of Integer) = New List(Of Integer)

                    copy_lists(temp5, temp1)
                    copy_lists(temp6, temp2)

                    temp6.Remove(-1)
                    temp6.Add(cFunc)
                    Path_Nodes.Add(temp5)
                    Path_Funcs.Add(temp6)

                Else

                    If check_touch(cNode, temp1) = False And check_touch(cFunc, temp2) = False Then

                        Dim temp3 As List(Of Integer) = New List(Of Integer)
                        Dim temp4 As List(Of Integer) = New List(Of Integer)

                        copy_lists(temp3, temp1)
                        copy_lists(temp4, temp2)



                        temp3.Add(cNode)
                        temp4.Add(cFunc)

                        qu.Enqueue(cNode)
                        nodespath.Enqueue(temp3)
                        funcspath.Enqueue(temp4)
                    End If
                End If
            Next

        End While


    End Sub


End Class
