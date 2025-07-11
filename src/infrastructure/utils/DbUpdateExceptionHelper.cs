using Microsoft.EntityFrameworkCore;

namespace med_consult_api.src.infrastructure;

public static class DbUpdateExceptionHelper
{
    public static string GetUniqueConstraintMessage(DbUpdateException dbEx)
    {
        var inner = dbEx.InnerException?.Message?.ToLowerInvariant();

        if (inner is null) return "Erro de banco de dados desconhecido.";

        if (inner.Contains("ix_userprofile_email"))
            return "Já existe um perfil com este email.";

        if (inner.Contains("ix_userprofile_telephone"))
            return "Já existe um perfil com este telefone.";

        if (inner.Contains("ix_authuser_username"))
            return "Este nome de usuário já está em uso.";

        if (inner.Contains("ix_role_name"))
            return "Já existe uma role com este nome.";

        if (inner.Contains("ix_exam_name"))
            return "Já existe um tipo de exame com este nome.";

        if (inner.Contains("ix_examcategory_name"))
            return "Já existe uma categoria de exame com este nome.";

        if (inner.Contains("ix_consult_name"))
            return "Já existe um tipo de consulta com este nome.";

        if (inner.Contains("ix_subsystemhealth_name"))
            return "Já existe um subsistema de saúde com este nome.";

        if (inner.Contains("ix_speciality_name"))
            return "Já existe uma especialidade com este nome.";

        return "Erro de mapeamento, verifique as relações ou os campos obrigatórios.";
    }
}