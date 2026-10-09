Namespace Services.UserCase
    Public Class RegisterRequest(Of TRepository As FoundationLibrary.Repositories.IRepository(Of Int32, Core.Entity.Entity))
        Private Repository As TRepository
        Sub New(RepositoryLink As TRepository)
            Repository = RepositoryLink
        End Sub

        Function Register(Of DTO)(DTOlink As DTO) As FoundationLibrary.Results.Result
            Dim Username As Core.Ables.IUserName = Nothing
            Dim Phone As Core.Ables.IPhone = Nothing
            Dim Email As Core.Ables.IEmail = Nothing


            If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IUserName)) Then Username = CType(DTOlink, Core.Ables.IUserName)
            If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IPhone)) Then Phone = CType(DTOlink, Core.Ables.IPhone)
            If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IEmail)) Then Email = CType(DTOlink, Core.Ables.IEmail)


            If Username IsNot Nothing AndAlso Repository.Exist(Username).Success = True Then Return New FoundationLibrary.Results.Result(False, "Δεν μπόρεσε να γίνει εγραφή λογο UserName.")
            If Phone IsNot Nothing AndAlso Repository.Exist(Phone).Success = True Then Return New FoundationLibrary.Results.Result(False, "Δεν μπόρεσε να γίνει εγραφή λογο Phone.")
            If Email IsNot Nothing AndAlso Repository.Exist(Email).Success = True Then Return New FoundationLibrary.Results.Result(False, "Δεν μπόρεσε να γίνει εγραφή λογο Email.")

            Return New FoundationLibrary.Results.Result(True, "Επιτυχής έλενχος")
        End Function
    End Class

End Namespace

