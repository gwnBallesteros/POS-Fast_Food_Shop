'Name of the Program         POS Fast Food Shop
'Developer                   G.T. Ballesteros
'Date                        June 28, 2022
'Purpose                     This is a point of sale system in a fast food shop
'                            and this you can pick items and calculate the amount
'                            and also to print recipt.

Imports System.Drawing.Printing
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
        btnPrint.Enabled = False
    End Sub

    'In the Panel Numbers
    Private Sub NumbersOnly(sender As Object, e As EventArgs) Handles btnZero.Click, btnTwo.Click, btnThree.Click, btnSix.Click, btnSeven.Click, btnOne.Click, btnNine.Click, btnFour.Click, btnFive.Click, btnEight.Click, btnDot.Click
        Dim b As Button = sender

        If (lblCash.Text = "0" And lblCashIn.Text = "0") Then
            lblCash.Text = String.Empty
            lblCash.Text = String.Empty
            lblCash.Text = b.Text
            lblCashIn.Text = b.Text

        ElseIf (b.Text = ".") Then
            If (Not lblCash.Text.Contains(".") And Not lblCashIn.Text.Contains(".")) Then
                lblCash.Text = lblCash.Text + b.Text
                lblCashIn.Text = lblCashIn.Text + b.Text
            End If
        Else
            lblCash.Text = lblCash.Text + b.Text
            lblCashIn.Text = lblCashIn.Text + b.Text
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
        btnPrint.Enabled = True

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

        btnPrint.Enabled = False
    End Sub

    'Coke Button in the Items
    Private Sub btnCoke_Click(sender As Object, e As EventArgs) Handles btnCoke.Click
        Dim CostOfItem As Double = 34.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Beverage Can Coca-Cola 330ml" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Can Coca-Cola" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Can Coca-Cola", "1", CostOfItem)
        AddCost()
    End Sub

    'Fanta Button in the Items
    Private Sub btnFanta_Click(sender As Object, e As EventArgs) Handles btnFanta.Click
        Dim CostOfItem As Double = 36.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Beverage Can Fanta 330ml" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Can Fanta" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Can Fanta", "1", CostOfItem)
        AddCost()
    End Sub

    'Soju Button in the Items
    Private Sub btnSoju_Click(sender As Object, e As EventArgs) Handles btnSoju.Click
        Dim CostOfItem As Double = 149.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Jinro Chamisul Oiginal Soju 360ml" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Soju Orig" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Soju Orig", "1", CostOfItem)
        AddCost()
    End Sub

    'Adez Button in the Items
    Private Sub btnAdez_Click(sender As Object, e As EventArgs) Handles btnAdez.Click
        Dim CostOfItem As Double = 199.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("AdeZ Surprising Joy Drink 800ml" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "AdeZ Drink" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Adez Drink", "1", CostOfItem)
        AddCost()
    End Sub

    'Coffee Button in the Items
    Private Sub btnCoffee_Click(sender As Object, e As EventArgs) Handles btnCoffee.Click
        Dim CostOfItem As Double = 90.75
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Coffee Latte" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Coffee Latte" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Coffee Latte", "1", CostOfItem)
        AddCost()
    End Sub

    'Lays Button in the Items
    Private Sub btnLaysClassic_Click(sender As Object, e As EventArgs) Handles btnLaysClassic.Click
        Dim CostOfItem As Double = 189.25
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Lays Classic Potato Chips 184.2g" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Lays Classic" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Lays Classic", "1", CostOfItem)
        AddCost()
    End Sub

    'Doritos Button in the Items
    Private Sub btnDoritos_Click(sender As Object, e As EventArgs) Handles btnDoritos.Click
        Dim CostOfItem As Double = 249.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Doritos Cool Ranch Chips 198g" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Doritos Chips" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Doritos Chips", "1", CostOfItem)
        AddCost()
    End Sub

    'Chitz Button in the Items
    Private Sub btnChitz_Click(sender As Object, e As EventArgs) Handles btnChitz.Click
        Dim CostOfItem As Double = 99.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Hotz Cheese Sticks Chips 125g" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Hotz Chips" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Hotz Chips", "1", CostOfItem)
        AddCost()
    End Sub

    'Wavy Button in the Items
    Private Sub btnWavy_Click(sender As Object, e As EventArgs) Handles btnWavy.Click
        Dim CostOfItem As Double = 198.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Lays Wavy Original Chips 184g" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Lays Wavy" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Lays Wavy", "1", CostOfItem)
        AddCost()
    End Sub

    'Lorenz Button in the Items
    Private Sub btnLorenz_Click(sender As Object, e As EventArgs) Handles btnLorenz.Click
        Dim CostOfItem As Double = 287.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Lorenz Chipsletten Paprika 100g" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Lorenz Chipsletten" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Lorenz Chipsletten", "1", CostOfItem)
        AddCost()
    End Sub

    'Tempura Button in the Items
    Private Sub btnTempura_Click(sender As Object, e As EventArgs) Handles btnTempura.Click
        Dim CostOfItem As Double = 150.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Shrimp Tempura 5pcs" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Shrimp Tempura" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Shrimp Tempura", "1", CostOfItem)
        AddCost()
    End Sub

    'Wedges Button in the Items
    Private Sub btnWedges_Click(sender As Object, e As EventArgs) Handles btnWedges.Click
        Dim CostOfItem As Double = 189.99
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Potato Wedges Bucket with Dips" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Wedges bckt with Dips" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Wedges bckt with Dips", "1", CostOfItem)
        AddCost()
    End Sub

    'Sausage Button in the Items
    Private Sub btnSausage_Click(sender As Object, e As EventArgs) Handles btnSausage.Click
        Dim CostOfItem As Double = 75.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Sausage Croissant 1 piece" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Sausage Croissant" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Sausage Croissant", "1", CostOfItem)
        AddCost()
    End Sub

    'Eggs Button in the Items
    Private Sub btnEggs_Click(sender As Object, e As EventArgs) Handles btnEggs.Click
        Dim CostOfItem As Double = 60.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Fried Sunny Side-Up Eggs 2 pieces" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Fried Eggs" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Fried Eggs", "1", CostOfItem)
        AddCost()
    End Sub

    'Salad Button in the Items
    Private Sub btnSalad_Click(sender As Object, e As EventArgs) Handles btnSalad.Click
        Dim CostOfItem As Double = 199.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Salad Set Package" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Salad Set" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Salad Set", "1", CostOfItem)
        AddCost()
    End Sub

    'Fried Chicken Button in the Items
    Private Sub btnFriedChicken_Click(sender As Object, e As EventArgs) Handles btnFriedChicken.Click
        Dim CostOfItem As Double = 399.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("1 Bucket Fried Chicken" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Fried Chicken" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Bckt Fried Chicken", "1", CostOfItem)
        AddCost()
    End Sub

    'Pizza Button in the Items
    Private Sub btnPizza_Click(sender As Object, e As EventArgs) Handles btnPizza.Click
        Dim CostOfItem As Double = 520.5
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("New York Style Pizza" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "NY style pizza" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("NY style pizza", "1", CostOfItem)
        AddCost()
    End Sub

    'Burger Button in the Items
    Private Sub btnBurger_Click(sender As Object, e As EventArgs) Handles btnBurger.Click
        Dim CostOfItem As Double = 150.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Extra Champ Burger" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Champ Burger" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Champ Burger", "1", CostOfItem)
        AddCost()
    End Sub

    'Hotdog Button in the Items
    Private Sub btnHotDog_Click(sender As Object, e As EventArgs) Handles btnHotDog.Click
        Dim CostOfItem As Double = 50.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("Hotdog Sandwich" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "Hotdog Sandwich" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("Hotdog Sandwich", "1", CostOfItem)
        AddCost()
    End Sub

    'Fries Button in the Items
    Private Sub btnFries_Click(sender As Object, e As EventArgs) Handles btnFries.Click
        Dim CostOfItem As Double = 50.0
        For Each Row As DataGridViewRow In DataGridView1.Rows
            lblPrices.Text = ("French Fries Medium Siza" & ControlChars.CrLf & CostOfItem.ToString("C2"))
            If Row.Cells(0).Value = "French Fries" Then
                Row.Cells(1).Value = Double.Parse(Row.Cells(1).Value + 1)
                Row.Cells(2).Value = Double.Parse(Row.Cells(1).Value) * CostOfItem
                AddCost()
                Exit Sub
                AddCost()
            End If
        Next

        DataGridView1.Rows.Add("French Fries", "1", CostOfItem)
        AddCost()
    End Sub

    'Print Button and Function starts here

    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer
    Sub changelongpaper()
        Dim rowcount As Integer
        longpaper = 0
        rowcount = DataGridView1.Rows.Count
        longpaper = rowcount * 15
        longpaper = longpaper + 200
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        changelongpaper()
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()  'Direct Print
    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        'pagesetup.PaperSize = New PaperSize("Custom", 250, 500) 'fixed size
        pagesetup.PaperSize = New PaperSize("Custom", 250, longpaper)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        'For Date and Time
        Dim dtmSystemDateTime As Date
        dtmSystemDateTime = Now

        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Tahoma", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        'font alignment
        Dim right As New StringFormat
        Dim center As New StringFormat

        right.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        line = "--------------------------------------------------------------------------"

        Dim rand As New Random
        Dim intInvoice As Integer
        intInvoice = rand.Next(1000000) + 100000

        'range from top
        e.Graphics.DrawString("24/7 Fast Food Shop", f14, Brushes.Black, centermargin, 5, center)
        e.Graphics.DrawString("Massachussetts Street 27 Avenue, Clark", f10, Brushes.Black, centermargin, 25, center)
        e.Graphics.DrawString("Tel +0967827384", f10, Brushes.Black, centermargin, 40, center)

        e.Graphics.DrawString("Invoice ID", f8, Brushes.Black, 0, 60)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 60)
        e.Graphics.DrawString(intInvoice, f8, Brushes.Black, 70, 60)

        e.Graphics.DrawString("Cashier", f8, Brushes.Black, 0, 75)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 75)
        e.Graphics.DrawString("James Bond", f8, Brushes.Black, 70, 75)

        e.Graphics.DrawString(dtmSystemDateTime, f8, Brushes.Black, 0, 90)

        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 100)

        Dim height As Integer 'DGV Position
        Dim i As Long
        DataGridView1.AllowUserToAddRows = False
        'If DataGridView1.CurrentCell.Value Is Nothing Then
        '    Exit Sub
        'Else
        For row As Integer = 0 To DataGridView1.RowCount - 1
            height += 15
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(1).Value.ToString, f10, Brushes.Black, 0, 100 + height)
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(0).Value.ToString, f10, Brushes.Black, 25, 100 + height)

            i = DataGridView1.Rows(row).Cells(2).Value
            DataGridView1.Rows(row).Cells(2).Value = Format(i, "##,##0")
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(2).Value.ToString, f10, Brushes.Black, rightmargin, 100 + height, right)
        Next
        'End If

        Dim height2 As Integer
        height2 = 110 + height
        sumqty() 'call sub
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, height2)
        e.Graphics.DrawString("Total: " & lblTotal.Text, f10b, Brushes.Black, rightmargin, 10 + height2, right)
        e.Graphics.DrawString(t_qty, f10b, Brushes.Black, 0, 10 + height2)
        e.Graphics.DrawString("Tax: " & lblTax.Text, f10, Brushes.Black, rightmargin, 22 + height2, right)
        e.Graphics.DrawString("Cash: " & lblCash.Text, f10, Brushes.Black, rightmargin, 35 + height2, right)
        e.Graphics.DrawString("Change: " & lblChange.Text, f10, Brushes.Black, rightmargin, 46 + height2, right)
        e.Graphics.DrawString("~ Thanks for shopping ~", f10, Brushes.Black, centermargin, 65 + height2, center)
        e.Graphics.DrawString("~ Please Come Again! ~", f10, Brushes.Black, centermargin, 78 + height2, center)
    End Sub

    Dim t_qty As Long
    Sub sumqty()

        Dim countqty As Long = 0
        For rowitem As Long = 0 To DataGridView1.RowCount - 1
            countqty = countqty + DataGridView1.Rows(rowitem).Cells(1).Value
        Next
        t_qty = countqty
    End Sub
End Class