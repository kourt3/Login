Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class Application

    <TestMethod()> Public Sub RegisterAndLoginMethod()
        Dim a As New Login.Application.Services.LoginServiceCloneEntity
        Dim RegisterVal As FoundationLibrary.Interfaces.ValMsg.IValMsg(Of Login.Core.Entity.Entity) = Register(a, "Kourt", "Kourt")
        Dim LoginVal As FoundationLibrary.Interfaces.ValMsg.IValMsg(Of Login.Core.Entity.Entity) = Login(a, "Kourt", "Kourt")


        Assert.AreEqual(RegisterVal.Success, LoginVal.Success)
    End Sub

    Public Function Register(a As Login.Application.Services.LoginServiceCloneEntity, Username As String, Password As String) As FoundationLibrary.ValMsg.ValMsg(Of Login.Core.Entity.Entity)

        Dim DTO As Login.Application.DTOs.IRegisterDTO = New Login.Application.DTOs.DTOs
        DTO.Username = Username
        DTO.Password = Password
        Return a.Register(DTO)

    End Function
    Public Function Login(a As Login.Application.Services.LoginServiceCloneEntity, Username As String, Password As String) As FoundationLibrary.ValMsg.ValMsg(Of Login.Core.Entity.Entity)
        Dim LoginDTO As Login.Application.DTOs.ILoginDTO = New Login.Application.DTOs.DTOs
        LoginDTO.Username = Username
        LoginDTO.Password = Password

        Return a.Login(LoginDTO)
    End Function
End Class