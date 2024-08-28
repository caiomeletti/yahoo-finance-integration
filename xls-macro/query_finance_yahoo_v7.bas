Attribute VB_Name = "Módulo1"
Function CarregaIndices() As Scripting.Dictionary
    Dim dicIndices As New Scripting.Dictionary
    
    dicIndices.Add "IBOV", "^BVSP"
    dicIndices.Add "IFIX", "IFIX.SA"
    dicIndices.Add "BDRX", "BDRX.SA"
    
    Set CarregaIndices = dicIndices
End Function

Sub BuscarCotacaoAtivos()
    Dim Http As New WinHttpRequest
    Dim arrValues() As String
    Dim urlBase As String
    Dim ticker As String
    Dim flagErr As Integer
    
    Dim dicIndices
    Set dicIndices = CarregaIndices()
    
    flagErr = 0
    urlBase = "https://query1.finance.yahoo.com/v7/finance/download/"
    ultLin = Cells(Rows.Count, 1).End(xlUp).Row
    
    periodo1 = DateDiff("s", "1/1/1970", Date)
    periodo2 = DateDiff("s", "1/1/1970", Now)
    
    Cells(3, 10).Value = ""
    For lin = 2 To ultLin
        If flagErr > 3 Then
            Cells(3, 9).Value = Http.ResponseText
            Exit For
        End If
    
        ticker = Cells(lin, 1).Value
        If dicIndices.Exists(ticker) Then
            ticker = dicIndices(ticker)
        Else
            ticker = ticker & ".SA"
        End If
        
        linkCot = urlBase & _
            ticker & _
            "?period1=" & periodo1 & "&period2=" & periodo2 & _
            "&interval=1d&events=history"
    
        Http.Open "GET", linkCot, False
        Http.Send
    
        If Http.Status = 200 Then
            ValueRaw = WorksheetFunction.Clean(Replace(Http.ResponseText, "Date,Open,High,Low,Close,Adj Close,Volume", ""))
            arrValues = Split(ValueRaw, ",")
        
            Cells(lin, 2).Value = arrValues(0)
            Cells(lin, 3).Value = arrValues(1)
            Cells(lin, 4).Value = arrValues(2)
            Cells(lin, 5).Value = arrValues(3)
            Cells(lin, 6).Value = arrValues(4)
            Cells(lin, 7).Value = arrValues(5)
            Cells(lin, 8).Value = arrValues(6)
        Else
            Cells(lin, 2).Value = ""
            Cells(lin, 3).Value = ""
            Cells(lin, 4).Value = ""
            Cells(lin, 5).Value = ""
            Cells(lin, 6).Value = ""
            flagErr = flagErr + 1
        End If
    Next
    
    Cells(2, 10).Value = Now
End Sub

