Namespace Services.UserCase
    'Για καποιο λογο μου βγαίνει το ιδιο με το LoginRequest!


    Public Class RemoveAccRequest(Of TRepository As FoundationLibrary.Repositories.IRepository(Of Int32, Core.Entity.Entity))
        Private ReadOnly Repository As TRepository
        Sub New(Repository As TRepository)
            Me.Repository = Repository
        End Sub
        Shared Function Remove(Of DTO)(DTOLink As DTO, Repository As TRepository) As FoundationLibrary.Results.Result
            'Remove With Username
            If GetType(DTO) Is GetType(DTOs.IRemoveAccountUsernameDTO) AndAlso Repository.Exist(CType(DTOLink, Core.Ables.IUserName)).Success = False Then
                Return New FoundationLibrary.Results.Result(False, "Δεν Μπόρεσε να περάσει τον έλενχο")
            Else
                Dim DTOL As DTOs.IRemoveAccountUsernameDTO = DTOLink
                If Repository.Read(DTOL).Model.Password <> DTOL.Password Then Return New FoundationLibrary.Results.Result(False, "Δεν Μπόρεσε να περάσει τον έλενχο")
            End If

            'Remove with Email
            If GetType(DTO) Is GetType(DTOs.IRemoveAccountEmailDTO) AndAlso Repository.Exist(CType(DTOLink, Core.Ables.IEmail)).Success = False Then
                Return New FoundationLibrary.Results.Result(False, "Δεν Μπόρεσε να περάσει τον έλενχο")
            Else
                Dim DTOL As DTOs.IRemoveAccountEmailDTO = DTOLink
                If Repository.Read(DTOL).Model.Password <> DTOL.Password Then Return New FoundationLibrary.Results.Result(False, "Δεν Μπόρεσε να περάσει τον έλενχο")
            End If

            'Remove With Phone
            If GetType(DTO) Is GetType(DTOs.IRemoveAccountPhoneDTO) AndAlso Repository.Exist(CType(DTOLink, Core.Ables.IPhone)).Success = False Then
                Return New FoundationLibrary.Results.Result(False, "Δεν Μπόρεσε να περάσει τον έλενχο")
            Else
                Dim DTOL As DTOs.IRemoveAccountPhoneDTO = DTOLink
                If Repository.Read(DTOL).Model.Password <> DTOL.Password Then Return New FoundationLibrary.Results.Result(False, "Δεν Μπόρεσε να περάσει τον έλενχο")
            End If

            Return New FoundationLibrary.Results.Result(True, "Επιτυχής έλενχος!")
        End Function
    End Class
End Namespace
