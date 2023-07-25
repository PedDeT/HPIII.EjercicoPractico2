Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Visible = False
        Panel2.Visible = True
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = False

    End Sub
    Private Sub SalarioSemanalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalarioSemanalToolStripMenuItem.Click
        ShowPanel(Panel1)
        ClearTextBoxesAndNumericUpDowns(Panel1)
    End Sub
    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        ShowPanel(Panel3)
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.Click
        ShowPanel(Panel4)
    End Sub

    Private Sub CálculoDeInterésToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CálculoDeInterésToolStripMenuItem.Click
        ShowPanel(Panel5)
        ClearTextBoxesAndNumericUpDowns(Panel5)
    End Sub

    Private Sub PagoDeAutopistaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagoDeAutopistaToolStripMenuItem.Click
        ShowPanel(Panel6)
        ClearTextBoxesAndNumericUpDowns(Panel6)
    End Sub

    Private Sub FacturaDeTeléfonoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaDeTeléfonoToolStripMenuItem.Click
        ShowPanel(Panel7)
        ClearTextBoxesAndNumericUpDowns(Panel7)
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ShowPanel(panel As Panel)
        Dim container As Control = panel.Parent

        For Each p As Panel In container.Controls.OfType(Of Panel)()
            p.Visible = False
        Next

        panel.Visible = True
    End Sub
    Private Sub ClearTextBoxesAndNumericUpDowns(container As Control)
        For Each control As Control In container.Controls
            If TypeOf control Is TextBox Then
                Dim textBox As TextBox = DirectCast(control, TextBox)
                textBox.Clear()
            ElseIf TypeOf control Is NumericUpDown Then
                Dim numericUpDown As NumericUpDown = DirectCast(control, NumericUpDown)
                numericUpDown.Value = numericUpDown.Minimum
            ElseIf control.Controls.Count > 0 Then
                ClearTextBoxesAndNumericUpDowns(control)
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NumericUpDown7.Value = 0
        TextBox2.Text = String.Empty
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim salario_total As Double
        Dim horas_trabajadas As Integer = NumericUpDown7.Value
        salario_total = If(horas_trabajadas < 36, horas_trabajadas * 15, 525 + (horas_trabajadas - 35) * 22.5)
        TextBox2.Text = "B/." + salario_total.ToString("0.00")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        NumericUpDown10.Value = 0
        NumericUpDown11.Value = 0
        NumericUpDown12.Value = 0
        TextBox5.Text = String.Empty
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim monto_adeudado As Double = NumericUpDown10.Value
        Dim interesa_pagar As Double = NumericUpDown12.Value
        Dim dias_morosos As Integer = NumericUpDown11.Value
        Dim interes_porcentage As Double
        Dim monto_moroso As Double = monto_adeudado + interesa_pagar
        If dias_morosos <= 60 And dias_morosos >= 30 Then
            interes_porcentage = 0.02
            monto_moroso = monto_moroso + monto_moroso * interes_porcentage
        ElseIf dias_morosos <= 90 And dias_morosos > 60 Then
            interes_porcentage = 0.05
            monto_moroso = monto_moroso + monto_moroso * interes_porcentage
        ElseIf dias_morosos <= 129 And dias_morosos > 90 Then
            interes_porcentage = 0.07
            monto_moroso = monto_moroso + monto_moroso * interes_porcentage
        ElseIf dias_morosos > 129 Then
            interes_porcentage = 0.15
            monto_moroso = monto_moroso + monto_moroso * interes_porcentage
        End If
        TextBox5.Text = "B/." + monto_moroso.ToString("0.00")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        NumericUpDown8.Value = 0
        NumericUpDown9.Value = 0
        TextBox8.Text = String.Empty
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Dim item_seleccionado As String = ComboBox1.SelectedItem.ToString()
        If item_seleccionado = "Motocicleta" Then
            NumericUpDown8.Enabled = True
            NumericUpDown9.Enabled = False
        ElseIf item_seleccionado = "Bicicleta" Then
            NumericUpDown8.Enabled = False
            NumericUpDown9.Enabled = False
        ElseIf item_seleccionado = "Automóvil" Then
            NumericUpDown8.Enabled = True
            NumericUpDown9.Enabled = False
        ElseIf item_seleccionado = "Camión" Then
            NumericUpDown8.Enabled = True
            NumericUpDown9.Enabled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim item_seleccionado As String = If(ComboBox1.SelectedItem IsNot Nothing, ComboBox1.SelectedItem.ToString(), String.Empty)
        Dim monto_autopista As Double
        If item_seleccionado = "Bicicleta" Then
            monto_autopista = 1
            TextBox8.Text = "B/." + monto_autopista.ToString("0.00")
        ElseIf item_seleccionado = "Motocicleta" Then
            monto_autopista = NumericUpDown8.Value * 0.3
            TextBox8.Text = "B/." + monto_autopista.ToString("0.00")
        ElseIf item_seleccionado = "Automóvil" Then
            monto_autopista = NumericUpDown8.Value * 0.3
            TextBox8.Text = "B/." + monto_autopista.ToString("0.00")
        ElseIf item_seleccionado = "Camión" Then
            monto_autopista = (NumericUpDown8.Value * 0.3) + (NumericUpDown9.Value * 0.25)
            TextBox8.Text = "B/." + monto_autopista.ToString("0.00")
        Else
            TextBox8.Text = "Selección No válida"
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        NumericUpDown1.Value = 0
        NumericUpDown2.Value = 0
        NumericUpDown3.Value = 0
        NumericUpDown4.Value = 0
        NumericUpDown5.Value = 0
        NumericUpDown6.Value = 0
        TextBox9.Text = String.Empty
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim total_llamada As Double
        Dim local_am As Double = (NumericUpDown1.Value - 10) * 0.03
        If NumericUpDown1.Value <= 10 Then
            local_am = 0
        End If
        Dim local_pm As Double = (NumericUpDown2.Value - 10) * 0.06
        If NumericUpDown1.Value <= 10 Then
            local_pm = 0
        End If
        Dim nacional_am As Double = NumericUpDown3.Value * 0.06
        Dim nacional_pm As Double = NumericUpDown4.Value * 0.12
        Dim internacional_am As Double = NumericUpDown5.Value * 0.1
        Dim internacional_pm As Double = NumericUpDown6.Value * 0.2
        total_llamada = local_am + local_pm + nacional_am + nacional_pm + internacional_am + internacional_pm
        TextBox9.Text = "B/." + total_llamada.ToString("0.00")
    End Sub
End Class
