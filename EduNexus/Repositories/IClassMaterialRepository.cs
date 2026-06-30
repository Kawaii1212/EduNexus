using System.Collections.Generic;
using EduNexus.Models;

namespace EduNexus.Repositories;

public interface IClassMaterialRepository
{
    IEnumerable<ClassMaterial> GetAllMaterials();
    ClassMaterial? GetMaterialById(object id);
    void AddMaterial(ClassMaterial material);
    void UpdateMaterial(ClassMaterial material);
    void DeleteMaterial(ClassMaterial material);
    IEnumerable<ClassMaterial> GetMaterialsByStudentId(long studentId);
}
