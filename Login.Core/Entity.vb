Imports FoundationLibrary.Keys
Imports Login.Core.Ables

Namespace Entity
    Public Class Entity
        Implements IHasPrimaryKey(Of Integer)
        Implements Ables.IReference
        Implements Ables.IUserName
        Implements Ables.IPassword
        Implements Ables.ICreateAt
        Implements Ables.IPhone
        Implements Ables.IEmail

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Username As String Implements Ables.IUserName.Username
        Public Property Password As String Implements Ables.IPassword.Password
        Public Property CreateAt As Date Implements Ables.ICreateAt.CreateAt
        Public Property Phone As String Implements IPhone.Phone
        Public Property Email As String Implements IEmail.Email


        Sub New()

        End Sub
        Sub New(EntityReflection As Entity)
            With Me
                .PrimaryKey = EntityReflection.PrimaryKey
                .Username = EntityReflection.Username
                .Password = EntityReflection.Password
                .CreateAt = EntityReflection.CreateAt
                .Phone = EntityReflection.Phone
                .Email = EntityReflection.Email
            End With
        End Sub

    End Class

End Namespace







