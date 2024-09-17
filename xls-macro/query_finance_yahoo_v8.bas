Attribute VB_Name = "Módulo1"
Option Explicit

Function CarregaIndices() As Scripting.Dictionary
    Dim dicIndices As New Scripting.Dictionary
    
    dicIndices.Add "IBOV", "^BVSP"
    dicIndices.Add "IFIX", "IFIX.SA"
    dicIndices.Add "BDRX", "BDRX.SA"
    
    Set CarregaIndices = dicIndices
End Function

Sub BuscarCotacaoAtivos()
    Dim dicIndices
    Set dicIndices = CarregaIndices()
    
    Dim flagErr As Integer: flagErr = 0
    Dim urlBase As String: urlBase = "https://query1.finance.yahoo.com/v8/finance/chart/"
    Dim ultLin As Integer: ultLin = Cells(Rows.Count, 1).End(xlUp).Row
    
    Cells(3, 10).Value = ""
    
    Dim lin As Integer
    Dim ticker As String
    Dim requestUri As String
    Dim Http As New WinHttpRequest
    Dim arrValues() As String

    For lin = 2 To ultLin
        If flagErr > 3 Then
            Cells(3, 10).Value = Http.ResponseText
            Exit For
        End If
    
        ticker = Cells(lin, 1).Value
        If dicIndices.Exists(ticker) Then
            ticker = dicIndices(ticker)
        Else
            ticker = ticker & ".SA"
        End If
        
        requestUri = urlBase & _
            ticker & _
            "?metrics=high&interval=1d&range=1d"
    
        Http.Open "GET", requestUri, False
        Http.Send
    
        If Http.Status = 200 Then
            arrValues = Split(Http.ResponseText, ",")
        
            Cells(lin, 2).Value = Date
            Cells(lin, 3).Value = GetValue("open", arrValues)
            Cells(lin, 4).Value = GetValue("high", arrValues)
            Cells(lin, 5).Value = GetValue("low", arrValues)
            Cells(lin, 6).Value = GetValue("close", arrValues)
            Cells(lin, 7).Value = GetValue("adjclose", arrValues)
            Cells(lin, 8).Value = GetValue("volume", arrValues)
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

Function GetValue(key As String, arr() As String) As String

    Dim i As Integer, pos As Integer, v As String
    For i = 0 To UBound(arr)
        pos = InStrRev(arr(i), key)
        If pos > 0 Then
            v = Replace(arr(i), key, "")
            v = Replace(Replace(Replace(Replace(v, """", ""), ":", ""), "{", ""), "}", "")
            v = Replace(Replace(Replace(v, "indicatorsquote", ""), "[", ""), "]", "")
            Exit For
        End If
    Next i
    
    GetValue = v
End Function

