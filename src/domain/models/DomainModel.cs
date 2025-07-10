namespace med_consult_api.src.domain;

public abstract class DomainModel
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }

    public DomainModel()
    {
        Id = Guid.NewGuid();
        DeletedAt = null;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        IsDeleted = false;
        IsActive = true;
    }

    public DomainModel(
        Guid? id = null,
        bool? isDeleted = null,
        bool? isActive = null,
        DateTime? createdAt = null,
        DateTime? updatedAt = null,
        DateTime? deletedAt = null)
    {
        Id = id ?? Guid.NewGuid();
        DeletedAt = deletedAt;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        UpdatedAt = updatedAt ?? DateTime.UtcNow;
        IsDeleted = isDeleted ?? false;
        IsActive = isActive ?? true;
    }

    private void VerifyIsDeleted()
    {
        if (IsDeleted)
            throw new Exception("Recurso inexistente!");
    }

    public void MarkAsDeleted()
    {
        VerifyIsDeleted();

        IsDeleted = true;
        IsActive = false;
        DeletedAt = DateTime.UtcNow;
        Touch();
    }

    public void Activate()
    {
        VerifyIsDeleted();

        IsActive = true; Touch();
    }
    public void Deactivate()
    {
        VerifyIsDeleted();

        IsActive = false; Touch();
    }

    public void Touch() => UpdatedAt = DateTime.UtcNow;

    public override string ToString()
    {
        return $"[DomainModel] Id: {Id}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}, DeletedAt: {DeletedAt}, IsActive: {IsActive}, IsDeleted: {IsDeleted}";
    }

}
