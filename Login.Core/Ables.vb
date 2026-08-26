Imports FoundationLibrary.Keys
Namespace Ables
    Public Interface IUserName
        Property Username As String
    End Interface
    Public Interface IPassword
        Property Password As String
    End Interface
    Public Interface ICreateAt
        Property CreateAt As Date
    End Interface
    Public Interface IEmail
        Property Email As String
    End Interface
    Public Interface IPhone
        Property Phone As String
    End Interface


    Public Interface IReference
        Inherits IHasPrimaryKey(Of Integer)
    End Interface
End Namespace
