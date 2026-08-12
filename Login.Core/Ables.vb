Imports FoundationLibrary.Interfaces.Keys
Namespace Ables
    Public Interface IUserName
        Property Username As String
    End Interface
    Public Interface IPassword
        Property Password As String
    End Interface
    Public Interface CreateAt
        Property CreateAt As Date
    End Interface
    Public Interface IReference
        Inherits IHasPrimaryKey(Of Integer)
    End Interface
End Namespace
