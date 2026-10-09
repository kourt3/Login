Imports FoundationLibrary.Results
Imports FoundationLibrary.Keys
Imports FoundationLibrary.Repositories
Imports Login.Core
Imports Login.Infastructure

Namespace Services

    ''' <summary>
    ''' <Title>Service Με Model</Title>
    ''' <para>Μπορείς να περάσει ενα Model Εδω με τα ιδια κλειδια η με καποιο Mapper και να λειτουργησει ο Service, Αρκει να επιλέξεις δικο σου constractor.</para>
    ''' </summary>
    ''' <typeparam name="TModel">To Model Που Θέλεις να περάσεις</typeparam>
    ''' <typeparam name="TReposiroty">Το Αποθετήριο</typeparam>
    Public Class Service(Of TModel, TReposiroty As IRepository(Of Int32, Core.Entity.Entity))

        Inherits FoundationLibrary.Services.Service(Of Integer, TModel, Core.Entity.Entity, TReposiroty)

        Private Property ConstractCloneYourModel As Func(Of TModel)
        Private Property ExternalModelMemberizeClone As FoundationLibrary.Services.Service(Of Integer, TModel, Core.Entity.Entity, TReposiroty).DelMemberizeClone

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
        Sub New(AddresToMemberizeClone As FoundationLibrary.Services.Service(Of Integer, TModel, Login.Core.Entity.Entity, TReposiroty).DelMemberizeClone)
            MyBase.New(New Repository)
            ExternalModelMemberizeClone = AddresToMemberizeClone
        End Sub

        ''' <summary>
        ''' Επιλογή Repository, Συνδεσμος Mapper
        ''' </summary>
        ''' <param name="Repository">Το Αποθετηριο</param>
        ''' <param name="AddresToMemberizeClone">ο Mapper (Enity -> Model) (Address Link)</param>
        Sub New(Repository As TReposiroty, AddresToMemberizeClone As FoundationLibrary.Services.Service(Of Integer, TModel, Login.Core.Entity.Entity, TReposiroty).DelMemberizeClone)
            MyBase.New(Repository)
            ExternalModelMemberizeClone = AddresToMemberizeClone
        End Sub

        Public Overrides Function MemberizeClone(Entity As Entity.Entity) As TModel
            If GetType(TModel) = GetType(Core.Entity.Entity) Then
                Return CType(New Core.Entity.Entity(Entity), Object)
            End If

            If ExternalModelMemberizeClone Is Nothing Then
                Dim Model As TModel = ConstractCloneYourModel.Invoke

                If GetType(TModel).GetInterfaces().Contains(GetType(FoundationLibrary.Keys.IHasPrimaryKey(Of Integer))) Then DirectCast(Model, FoundationLibrary.Keys.IHasPrimaryKey(Of Integer)).PrimaryKey = Entity.PrimaryKey
                If GetType(TModel).GetInterfaces().Contains(GetType(Ables.IUserName)) Then DirectCast(Model, Ables.IUserName).Username = Entity.Username
                If GetType(TModel).GetInterfaces().Contains(GetType(Ables.IPassword)) Then DirectCast(Model, Ables.IPassword).Password = Entity.Password
                If GetType(TModel).GetInterfaces().Contains(GetType(Ables.ICreateAt)) Then DirectCast(Model, Ables.ICreateAt).CreateAt = Entity.CreateAt
                DirectCast(Model, FoundationLibrary.Keys.IHasExtrernalID(Of Integer).IHasToExternalID).ToExternalID = Entity.ToExternalID

                Return Model
            Else
                Return ExternalModelMemberizeClone.Invoke(Entity)
            End If

        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Optional Entity As Core.Entity.Entity = Nothing) As Entity.Entity

            If Entity Is Nothing Then
                Entity = New Entity.Entity
            End If

            With Entity
                If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IUserName)) Then .Username = CType(DTOLink, Core.Ables.IUserName).Username
                If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IPassword)) Then .Password = CType(DTOLink, Core.Ables.IPassword).Password
                If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IEmail)) Then .Email = CType(DTOLink, Core.Ables.IEmail).Email
                If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IPhone)) Then .Phone = CType(DTOLink, Core.Ables.IPhone).Phone
                If GetType(DTO).GetInterfaces().Contains(GetType(FoundationLibrary.Keys.IHasExtrernalID(Of Integer).IHasToExternalID)) Then .ToExternalID = CType(DTOLink, FoundationLibrary.Keys.IHasExtrernalID(Of Integer).IHasToExternalID).ToExternalID

            End With

            Return Entity
        End Function

        Public Overrides Function ToValidation(Of DTO)(DTOLink As DTO) As IErrResult(Of List(Of FoundationLibrary.Errors.IErrors))
            Dim ValidUserName As New FoundationLibrary.Validation.Types.ValidString With {.ValidSymbols = False, .AvailableNothin = False, .AvailableWhiteSpace = False}
            Dim ValidPassword As New FoundationLibrary.Validation.Types.ValidString With {.MinLength = 5, .MaxLength = 20}
            Dim ValidPhone As New FoundationLibrary.Validation.Types.ValidInteger
            Dim ValidEmail As New FoundationLibrary.Validation.Types.ValidString With {.AvailableNothin = False, .AvailableWhiteSpace = False}

            Dim Valid As New List(Of FoundationLibrary.Errors.IErrors)

            If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IUserName)) Then Valid.AddRange(ValidUserName.Check(CType(DTOLink, Core.Ables.IUserName).Username).Err)
            If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IPassword)) Then Valid.AddRange(ValidPassword.Check(CType(DTOLink, Core.Ables.IPassword).Password).Err)
            If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IEmail)) Then Valid.AddRange(ValidEmail.Check(CType(DTOLink, Core.Ables.IEmail).Email).Err)
            If GetType(DTO).GetInterfaces().Contains(GetType(Core.Ables.IPhone)) Then Valid.AddRange(ValidPhone.Check(CType(DTOLink, Core.Ables.IPhone).Phone).Err)

            If Valid.Count = 0 Then
                Return New ErrResult(Of List(Of FoundationLibrary.Errors.IErrors))(True, "Επιτηχης έλενχος")
            Else

                Return New ErrResult(Of List(Of FoundationLibrary.Errors.IErrors))(False, "Αποτυχια διαπιστοθηκαν προβληματα κατα τον ελενχο!", Valid)
            End If

        End Function
    End Class
End Namespace