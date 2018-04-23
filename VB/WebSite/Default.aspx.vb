Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.XtraSpellChecker
Imports DevExpress.Web.ASPxSpellChecker
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
	End Sub

	Private strResult As StringBuilder

	Protected Sub btn_Click(ByVal sender As Object, ByVal e As EventArgs)
		strResult = New StringBuilder()
		Dim correctedText As String = CheckText(memo.Text)

		lbl.Text = strResult.ToString()

		memo.Text = correctedText
	End Sub

	Private Function CheckText(ByVal text As String) As String
		Dim checker As New SpellCheckerBase()

		AddHandler checker.NotInDictionaryWordFound, AddressOf checker_NotInDictionaryWordFound

		Dim dict As New SpellCheckerISpellDictionary(Server.MapPath("~/Dictionaries/american.xlg"), Server.MapPath("~/Dictionaries/english.aff"), New CultureInfo("en-us"))
		dict.AlphabetPath = Server.MapPath("~/Dictionaries/EnglishAlphabet.txt")
		dict.CacheKey = "ispellDic"
		dict.Load()

		checker.Dictionaries.Add(dict)

		checker.LevenshteinDistance = 4

		Dim result As String = checker.Check(text)

		Return result
	End Function

	Private Sub checker_NotInDictionaryWordFound(ByVal sender As Object, ByVal e As NotInDictionaryWordFoundEventArgs)
		e.Result = SpellCheckOperation.Ignore

		If e.Suggestions.Count > 0 Then
			Dim str As New List(Of String)()
			For Each s As SuggestionBase In e.Suggestions
				str.Add(s.Suggestion)
			Next s

			strResult.AppendFormat("<b>{0}</b> - {1}<br/>", e.Word, String.Join(", ", str.ToArray()))
		End If

		e.Handled = True
	End Sub
End Class
