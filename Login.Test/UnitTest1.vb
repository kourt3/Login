Imports System.Text
Imports FoundationLibrary.Interfaces.Keys
Imports Login.Core.Ables
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1
    Public Class Model
        Implements FoundationLibrary.Interfaces.Keys.IHasPrimaryKey(Of Integer)
        Implements Core.Ables.IReference
        Implements Core.Ables.IUserName

        Implements Core.Ables.CreateAt

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Username As String Implements IUserName.Username
        Public Property CreateAt As Date Implements CreateAt.CreateAt

    End Class



    <TestMethod()> Public Sub TestMethod1()
        Dim ServiceForModel As New Login.Application.Services.LoginServiceModel(Of Model, Infastructure.Repository)(Function() New Model)
        Dim DTO As Login.Application.DTOs.IRegisterDTO = New Login.Application.DTOs.DTOs

        DTO.Username = "kourt"
        DTO.Password = "kourt"

        Dim newEntity As New Core.Entity.Entity
        With newEntity
            .PrimaryKey = 1
            .Username = "kourt"
            .Password = "kourt"
            .CreateAt = "23/06/1995"
        End With

        Dim Model As New Model

        Model = ServiceForModel.MemberizeClone(newEntity)

        Console.WriteLine(Model.Username)


    End Sub

End Class