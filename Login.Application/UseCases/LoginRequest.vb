Imports Login.Core.Ables
Imports FoundationLibrary.Repositories
Imports FoundationLibrary.Results

Namespace Services.UserCase
    Public Class LoginRequest(Of TRepostiry As IRepository(Of Int32, Core.Entity.Entity))
        Private ReadOnly Repository As TRepostiry

        Sub New(Repository As TRepostiry)
            Me.Repository = Repository
        End Sub

        Function Login(Of DTO)(LoginDTO As DTO) As Result
            Dim RepResult As Result(Of Core.Entity.Entity) = Nothing
            If GetType(DTO) Is GetType(DTOs.ILoginUserNameDTO) Then
                Dim DTOLink As DTOs.ILoginUserNameDTO = LoginDTO
                If Repository.Exist(DTOLink.Username).Success = False Then Return New Result(False, "Δεν Ήταν επυτιχης το Login λογο Username.")
                If Repository.Read(DTOLink.Username).Model.Password <> DTOLink.Password Then Return New Result(False, "Προβλήμα με το autheration!")
                Return New FoundationLibrary.Results.Result(True, "Επιτήχης έλενχος δεδομένον!")
            End If

            If GetType(DTO) Is GetType(DTOs.ILoginEmailDTO) Then
                Dim DTOLink As DTOs.ILoginEmailDTO = LoginDTO
                If Repository.Exist(DTOLink.Email).Success = False Then Return New Result(False, "Δεν Ήταν επυτιχης το Login λογο Email.")
                If Repository.Read(DTOLink.Email).Model.Password <> DTOLink.Password Then Return New Result(False, "Προβλήμα με το autheration!")
                Return New FoundationLibrary.Results.Result(True, "Επιτήχης έλενχος δεδομένον!")
            End If

            If GetType(DTO) Is GetType(DTOs.ILoginPhoneDTO) Then
                Dim DTOLink As DTOs.ILoginPhoneDTO = LoginDTO
                If Repository.Exist(DTOLink.Phone).Success = False Then Return New Result(False, "Δεν Ήταν επυτιχης το Login λογο Phone.")
                If Repository.Read(DTOLink.Phone).Model.Password <> DTOLink.Password Then Return New Result(False, "Προβλήμα με το autheration!")
                Return New FoundationLibrary.Results.Result(True, "Επιτήχης έλενχος δεδομένον!")
            End If

            Return New FoundationLibrary.Results.Result(True, "Επιτήχης έλενχος δεδομένον!")
        End Function
    End Class

End Namespace

