Public Class Form1
    Dim msg1 As String
    Dim msg2 As String
    Dim convoi_status As Boolean
    Dim convoi_fehler As Boolean
    Dim time As Integer
    Dim i As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        convoi()
        If convoi_fehler = True Then Exit Sub 'Bei Fehler --> abbruch
        MsgBox("Bitte in den ETS2 wechseln und warten bis sich der Chat öffnet. Du kannst ihn dann einfach schließen.")
        System.Threading.Thread.Sleep(10000)
        Timer1.Start()
        SendKeys.Send("y" + "/fix Antikick wurde aktiviert! Du kannst den Chat schließen.")
        Button1.Enabled = False
        Button2.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        convoi()
        System.Threading.Thread.Sleep(750)
        SendKeys.SendWait("y" + "Spedition gesucht? ---->  TS: dsltrans.pancraft.de" + "{ENTER}")
        If convoi_status = True Then
            System.Threading.Thread.Sleep(750)
            SendKeys.SendWait("y" + msg1 + "{Enter}")
            System.Threading.Thread.Sleep(750)
            SendKeys.SendWait("y" + msg2 + "{Enter}")
        End If
        If Timer1.Interval <> time Then Timer1.Interval = time
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Stop()
        Button1.Enabled = True
        Button2.Enabled = False
    End Sub

    Private Sub convoi()
        If CheckBox1.Checked = True Then
            If TextBox1.Text.Contains("von") Or TextBox2.Text.Contains("nach") Then
                MsgBox("Fehler! Du hast den Start oder das Ende des Convois nicht geändert! bzw. einen Flüchtigkeitsfehler gemacht! Bei Rechtschreibfehlern wird nicht gewarnt!", MsgBoxStyle.Exclamation)
                convoi_fehler = True
                convoi_status = False
                Return
            End If
            msg1 = "Heute um " + MaskedTextBox1.Text + " Uhr Convoi von"
            msg2 = TextBox1.Text + " nach " + TextBox2.Text + ". Es besteht Anwesenheitspflicht auf dem TS dsltrans.pancraft.de."
            convoi_status = True
            convoi_fehler = False
        Else
            convoi_status = False
            convoi_fehler = False
        End If

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        time = 1
        i = 0
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If i = 0 Then
            time = 1
            i = 1
            Button4.Text = "Intervall: " + time + " min"
        ElseIf i = 1 Then
            time = 2
            i = 2
            Button4.Text = "Intervall: " + time + " min"
        ElseIf i = 2 Then
            time = 3
            i = 0
            Button4.Text = "Intervall: " + time + " min"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        convoi()
        System.Threading.Thread.Sleep(750)
        SendKeys.SendWait("y" + "Spedition gesucht? ---->  TS: dsltrans.pancraft.de" + "{ENTER}")
        If convoi_status = True Then
            System.Threading.Thread.Sleep(750)
            SendKeys.SendWait("y" + msg1 + "{Enter}")
            System.Threading.Thread.Sleep(750)
            SendKeys.SendWait("y" + msg2 + "{Enter}")
        End If
        If Timer1.Interval <> time Then Timer1.Interval = time
    End Sub
End Class