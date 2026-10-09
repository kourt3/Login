Imports System.Text
Imports FoundationLibrary.Keys
Imports Login.Core.Ables
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    Dim ServiceForModel As New Login.Application.Services.Service(Of Core.Entity.Entity, Infastructure.Repository)
    <TestMethod()> Public Sub RegisterMethod1()
        Dim DTO As Login.Application.DTOs.IRegisterUserNameDTO = New Login.Application.DTOs.DTOs

        DTO.Username = "kourt"
        DTO.Password = "kourt"
        DTO.CreateAt = Now
        DTO.ToExternalID = 15

        ServiceForModel.Register(DTO)
        Console.WriteLine("------------ Register ------------")
        Console.WriteLine(RepositoryShow(ServiceForModel.Repository.ReadAT(0).Model))
        Console.WriteLine("----------------------------------")
        UpdateMethod2()
    End Sub

    Public Sub UpdateMethod2()
        Dim DTO As Login.Application.DTOs.IChangeUserNameDTO = New Login.Application.DTOs.DTOs
        DTO.Username = "Paok"

        Dim Entity As Login.Core.Entity.Entity = ServiceForModel.Repository.ReadAT(0).Model

        ServiceForModel.Change(Of Login.Application.DTOs.IChangeUserNameDTO)(Entity, DTO)
        Console.WriteLine("------------- Update -------------")
        Console.WriteLine(RepositoryShow(ServiceForModel.Repository.ReadAT(0).Model))
        Console.WriteLine("----------------------------------")

    End Sub

    Function RepositoryShow(Entity As Core.Entity.Entity) As String

        Return "ID: " & Entity.PrimaryKey & vbNewLine &
            "Username: " & Entity.Username & vbNewLine &
            "Password: " & Entity.Password & vbNewLine &
            "Phone: " & Entity.Phone & vbNewLine &
            "Email: " & Entity.Email & vbNewLine &
            "CreateAt: " & Entity.CreateAt.Date & vbNewLine &
            "ExternalID: " & Entity.ToExternalID
    End Function

End Class