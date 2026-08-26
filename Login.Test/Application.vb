Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class Application

    <TestMethod()> Public Sub RegisterAndLoginMethod()




    End Sub


    Public Function Register(a As Login.Application.Services.Service(Of Core.Entity.Entity, Infastructure.Repository), Username As String, Password As String) As FoundationLibrary.ValMsg.ValMsg(Of Login.Core.Entity.Entity)

    End Function

    Public Function Login(a As Login.Application.Services.Service(Of Core.Entity.Entity, Infastructure.Repository), Username As String, Password As String) As FoundationLibrary.ValMsg.ValMsg(Of Login.Core.Entity.Entity)

    End Function
End Class