Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class RegisterTest
    Dim a As New Login.Application.Services.LoginService


    <TestMethod()> Public Sub Register()

        Dim DTO As Login.Application.DTOs.IRegisterDTO = New Login.Application.DTOs.DTOs
        DTO.Username = "kourt"
        DTO.Password = "kourt"
        Dim Val As FoundationLibrary.ValMsg.ValMsg(Of Login.Core.Entity.Entity) = a.Register(DTO)

        Console.WriteLine(Val.ToString())


        Dim LoginDTO As Login.Application.DTOs.ILoginDTO = New Login.Application.DTOs.DTOs
        LoginDTO.Username = "kourt"
        LoginDTO.Password = "kourt"

        Console.WriteLine(a.Login(LoginDTO).ToString)


    End Sub

End Class