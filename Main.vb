Public Class Main

    'Calculate the Total and Tax of the Items
    Private Function Cost_Of_Items() As Double
        Dim Sum As Double = 0
        Dim i As Integer = 0

        For i = 0 To DataGridView1.Rows.Count - 1

            Sum = Sum + Convert.ToDouble(DataGridView1.Rows(i).Cells(2).Value)
        Next
        Return Sum
    End Function

    Sub AddCost()
        Dim tax, q As Double
        tax = 0.12

        If DataGridView1.Rows.Count > 0 Then
            lblTax.Text = FormatCurrency(((Cost_Of_Items() * tax) / 100).ToString("0.00"))
            lblSubTotal.Text = FormatCurrency(Cost_Of_Items().ToString("0.00"))
            q = (((Cost_Of_Items()) * tax) / 100)
            lblTotal.Text = FormatCurrency(q + Cost_Of_Items().ToString("0.00"))
        End If
    End Sub

    Sub Change()
        Dim tax, q, c As Double
        tax = 0.12

        If DataGridView1.Rows.Count > 0 Then
            q = ((Cost_Of_Items() * tax) / 100) + Cost_Of_Items()
            c = Val(lblCash.Text)
            lblChange.Text = FormatCurrency(c - q)
        End If
    End Sub

    'Reset Button
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        lblChange.Text = String.Empty
        lblCash.Text = "0"
        lblCashIn.Text = "0"
        lblSubTotal.Text = String.Empty
        lblTax.Text = String.Empty
        lblTotal.Text = String.Empty
        cboMop.Text = String.Empty
        lblPrices.Text = String.Empty
        lblDate.Text = Today
        lblTime.Text = TimeOfDay
        DataGridView1.Rows.Clear()
        DataGridView1.Refresh()
    End Sub

    'In the Panel Numbers
    Private Sub NumbersOnly(sender As Object, e As EventArgs) Handles btnZero.Click, btnTwo.Click, btnThree.Click, btnSix.Click, btnSeven.Click, btnOne.Click, btnNine.Click, btnFour.Click, btnFive.Click, btnEight.Click, btnDot.Click
        Dim b As Button = sender

        If (lblCash.Text = "0") Then
            lblCash.Text = ""
            lblCash.Text = b.Text

        ElseIf (b.Text = ".") Then
            If (Not lblCash.Text.Contains(".")) Then
                lblCash.Text = lblCash.Text + b.Text
            End If
        Else
            lblCash.Text = lblCash.Text + b.Text
            lblCashIn.Text = lblCash.Text
        End If
    End Sub

    'In the panel numbers C
    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        lblCash.Text = "0"
        lblCashIn.Text = "0"
        lblChange.Text = String.Empty
    End Sub

    'Main Load Form
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboMop.Items.Add("Cash")
        cboMop.Items.Add("G-Cash")
        cboMop.Items.Add("Visa Card")
        cboMop.Items.Add("Master Card")

        Dim dtmSystemDate As Date
        dtmSystemDate = Today
        lblDate.Text = dtmSystemDate

        Dim dtmSystemTime As Date
        dtmSystemTime = TimeOfDay
        lblTime.Text = dtmSystemTime

        lblPrices.Text = String.Empty
    End Sub

    'Pay Button
    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        If (cboMop.Text = "Cash") Then
            Change()
        Else
            lblChange.Text = String.Empty
            lblCash.Text = "0"
            lblCashIn.Text = "0"
        End If
    End Sub

    'Remove Item Button
    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        For Each row As DataGridViewRow In DataGridView1.SelectedRows
            DataGridView1.Rows.Remove(row)
        Next
        AddCost()

        If (cboMop.Text = "Cash") Then
            Change()
        Else
            lblChange.Text = String.Empty
            lblCash.Text = "0"
        End If
    End Sub

    'Coke Button in the Items
    Private Sub btnCoke_Click(sender As Object, e As EventArgs) Handles btnCoke.Click
        Dim CostOfItem As Double = 28.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Beverage Can Coca-Cola 330ml" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Can Coca-Cola" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Can Coca-Cola", "1", CostOfItem)

    End Sub

    'Fanta Buttons in the Items
    Private Sub btnFanta_Click(sender As Object, e As EventArgs) Handles btnFanta.Click
        Dim CostOfItem As Double = 26.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Beverage Can Fanta 330ml" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Can Fanta" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Can Fanta", "1", CostOfItem)
    End Sub
End Class