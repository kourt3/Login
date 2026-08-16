Imports FoundationLibrary.Interfaces.ValMsg
Imports FoundationLibrary.ValMsg
Imports Login.Core
Imports Login.Infastructure

Namespace Services

    ''' <summary>
    ''' <Title>Service Με Model</Title>
    ''' <para>Μπορείς να περάσει ενα Model Εδω με τα ιδια κλειδια η με καποιο Mapper και να λειτουργησει ο Service, Αρκει να επιλέξεις δικο σου constractor.</para>
    ''' </summary>
    ''' <typeparam name="TModel">To Model Που Θέλεις να περάσεις</typeparam>
    ''' <typeparam name="TReposiroty">Το Αποθετήριο</typeparam>
    Public Class LoginServiceModel(Of TModel As FoundationLibrary.Interfaces.Keys.IHasPrimaryKey(Of Int32), TReposiroty As {FoundationLibrary.Interfaces.Repository.IRepository(Of Int32, Core.Entity.Entity), IMyRepository})
        Inherits FoundationLibrary.Services.ServiceModel(Of Integer, TModel, Core.Entity.Entity, TReposiroty)

        Protected Friend Property ConstractCloneYourModel As Func(Of TModel)

        ''' <summary>
        ''' Αυτομάτος παράγει ενα Dynamic αποθητήριο
        ''' </summary>
        Sub New()
            MyBase.New(New Repository)
        End Sub
        ''' <summary>
        ''' Σε περιπτωση που θέλει καποιος να περασει διαφορετικο αποθετηριο
        ''' </summary>
        ''' <param name="Repository">To αποθετήριο.</param>
        Sub New(Repository As TReposiroty)
            MyBase.New(Repository)
        End Sub

        ''' <summary>
        ''' Σε περίπτωση που θέλεις να περάσεις ενα Model που να έχει τα ιδια κλειδια με το Project.<br/>
        ''' για να μπορέσει να ελένξει ποια κλειδια θα μπορέσει να περάσει στο δικο σου Model.
        ''' </summary>
        ''' <param name="ConstractYourModel">Constractor για το Model(Address Link)</param>
        Sub New(ConstractYourModel As Func(Of TModel))
            MyBase.New(New Repository)
            ConstractCloneYourModel = ConstractYourModel
        End Sub
        ''' <summary>
        ''' <para> Επιλογή Αποθετήριο , Constractor Model</para>
        ''' <para> Σε περίπτωση που θέλεις να περάσεις ενα Model που να έχει τα ιδια κλειδια με το Project.<br/>
        ''' για να μπορέσει να ελένξει ποια κλειδια θα μπορέσει να περάσει στο δικο σου Model.</para>
        ''' </summary>
        ''' <param name="Repository">Επιλογη Repository</param>
        ''' <param name="ConstractYourModel">Constractor απο το δικο σου Model (Address Link)</param>
        Sub New(Repository As TReposiroty, ConstractYourModel As Func(Of TModel))
            MyBase.New(Repository)
            ConstractCloneYourModel = ConstractYourModel
        End Sub

        ''' <summary>
        ''' ο συνδεσμος Mapper που θα κανει την αντικατασταση Enity σε Model 
        ''' </summary>
        ''' <param name="AddresToMemberizeClone">συνδεσμος Mapper (Entity -> Model)(Address Link)</param>
        Sub New(AddresToMemberizeClone As FoundationLibrary.Services.ServiceModel(Of Integer, TModel, Login.Core.Entity.Entity, TReposiroty).DelMemberizeClone)
            MyBase.New(New Repository, AddresToMemberizeClone)
        End Sub

        ''' <summary>
        ''' Επιλογή Repository, Συνδεσμος Mapper
        ''' </summary>
        ''' <param name="Repository">Το Αποθετηριο</param>
        ''' <param name="AddresToMemberizeClone">ο Mapper (Enity -> Model) (Address Link)</param>
        Sub New(Repository As TReposiroty, AddresToMemberizeClone As FoundationLibrary.Services.ServiceModel(Of Integer, TModel, Login.Core.Entity.Entity, TReposiroty).DelMemberizeClone)
            MyBase.New(Repository, AddresToMemberizeClone)

        End Sub

        Function Login(LoginDTO As DTOs.ILoginDTO) As FoundationLibrary.ValMsg.ValMsg(Of TModel)


            Dim Result As New ValMsg(Of TModel)
            If Repository.Exist(LoginDTO) Then
                Result.Success = True
                Result.Msg = "Βρέθηκε ο Χρήστης."
                Result.Model = MemberizeClone(Repository.Find(LoginDTO))
                Return Result
            End If

            Result.Success = False
            Result.Msg = "Δεν Βρέθηκε ο χρήστης!"
            Return Result
        End Function

        Public Overrides Function Change(Of DTO)(Ref As Entity.Entity, ChangeDTO As DTO) As IValMsg
            Dim Val As New ValMsg
            If TypeOf ChangeDTO Is Ables.IUserName Then
                Console.WriteLine("True")
                Dim ChangeDTOLink As Ables.IUserName = ChangeDTO
                If Repository.ExistByUsername(ChangeDTOLink.Username) Then
                    With Val
                        .Success = False
                        .Msg = "Παρακαλώ άλλαξε Username!"
                    End With
                    Return Val
                End If
            End If
            Return MyBase.Change(Ref, ChangeDTO)
        End Function

        Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As IValMsg(Of TModel)
            Dim LinkRegisterDTO As DTOs.IRegisterDTO = RegisterDTO
            Dim Val As New ValMsg(Of Entity.Entity)
            If Repository.ExistByUsername(LinkRegisterDTO.Username) Then
                With Val
                    .Success = False
                    .Msg = "Παρακαλώ άλλαξε Username!"
                End With
                Return Val
            End If

            Return MyBase.Register(RegisterDTO)
        End Function


        Public Overrides Function MemberizeClone(Entity As Entity.Entity) As TModel
            If MyBase.AvailableExternalModel = False Then
                Dim Model As TModel = ConstractCloneYourModel.Invoke

                If GetType(TModel).GetInterfaces().Contains(GetType(Ables.IReference)) Then DirectCast(Model, Ables.IReference).PrimaryKey = Entity.PrimaryKey
                If GetType(TModel).GetInterfaces().Contains(GetType(Ables.IUserName)) Then DirectCast(Model, Ables.IUserName).Username = Entity.Username
                If GetType(TModel).GetInterfaces().Contains(GetType(Ables.IPassword)) Then DirectCast(Model, Ables.IPassword).Password = Entity.Password
                If GetType(TModel).GetInterfaces().Contains(GetType(Ables.CreateAt)) Then DirectCast(Model, Ables.CreateAt).CreateAt = Entity.CreateAt

                Return Model
            Else
                Return MyBase.ExternalModelMemberizeClone.Invoke(Entity)
            End If

        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Entity.Entity


            If GetType(DTO) Is GetType(DTOs.ILoginDTO) Then
                Dim Obj As DTOs.ILoginDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IRegisterDTO) Then
                Dim Obj As DTOs.IRegisterDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeNameDTO) Then
                Dim Obj As DTOs.IChangeNameDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangePasswordDTO) Then
                Dim Obj As DTOs.IChangePasswordDTO = DTOLink
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As DTOs.IChangeUsernameAndPasswordDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            If GetType(DTO) Is GetType(DTOs.ILoginDTO) Then
                Dim Obj As DTOs.ILoginDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IRegisterDTO) Then
                Dim Obj As DTOs.IRegisterDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeNameDTO) Then
                Dim Obj As DTOs.IChangeNameDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangePasswordDTO) Then
                Dim Obj As DTOs.IChangePasswordDTO = DTOLink
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As DTOs.IChangeUsernameAndPasswordDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function

    End Class
End Namespace