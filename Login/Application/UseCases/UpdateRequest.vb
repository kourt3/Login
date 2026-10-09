Namespace Services.UserCase
    Public Class UpdateRequest(Of TRepository As FoundationLibrary.Repositories.IRepository(Of Int32, Core.Entity.Entity))
        Private ReadOnly Repository As TRepository
        Sub New(Repository As TRepository)
            Me.Repository = Repository
        End Sub

        Function Update(Of DTO)(DTOLink As DTO) As FoundationLibrary.Results.Result
            If GetType(DTO).GetInterfaces.Contains(GetType(Core.Ables.IUserName)) AndAlso Repository.Exist(CType(DTOLink, Core.Ables.IUserName)).Success Then Return New FoundationLibrary.Results.Result(False, "Δεν Μπορεί να γίνει αλλαγή λογο Username!")
            If GetType(DTO).GetInterfaces.Contains(GetType(Core.Ables.IEmail)) AndAlso Repository.Exist(CType(DTOLink, Core.Ables.IEmail)).Success Then Return New FoundationLibrary.Results.Result(False, "Δεν μπορεί να γίνει αλλαγή λόγο Email.")
            If GetType(DTO).GetInterfaces.Contains(GetType(Core.Ables.IPhone)) AndAlso Repository.Exist(CType(DTOLink, Core.Ables.IPhone)).Success Then Return New FoundationLibrary.Results.Result(False, "Δεν μπορεί να γίνει αλλαγή λόγο Phone.")
            Return New FoundationLibrary.Results.Result(True, "Επιτηχής έλενχος!")
        End Function
    End Class
End Namespace

