using EquitySolver.Dtos;
using MathNet.Numerics.LinearAlgebra;

// var list = new List<Company>
// {
//     new()
//     {
//         Name = "A",
//         OwnedCompanies = new Dictionary<string, double>
//         {
//             { "B", 0.1 }
//         }
//     },
//     new()
//     {
//         Name = "B",
//         OwnedCompanies = new Dictionary<string, double>
//         {
//             { "A", 0.05 },
//             { "C", 0.2 }
//         }
//     },
//     new()
//     {
//         Name = "C",
//         OwnedCompanies = new Dictionary<string, double>
//         {
//             { "A", 0.3 },
//             { "B", 0.15 }
//         }
//     }
// };

var list = new List<Company>
{
    new()
    {
        Name = "A",
        OwnedCompanies = new Dictionary<string, double>
        {
            { "B", 0.1 }
        }
    },
    new()
    {
        Name = "B",
        OwnedCompanies = new Dictionary<string, double>
        {
            { "C", 0.1 },
        }
    },
    new()
    {
        Name = "C",
        OwnedCompanies = new Dictionary<string, double>
        {
        }
    },
};


var ownership = new double[list.Count, list.Count];
for (var i = 0; i < list.Count; i++)
{
    var company = list[i];
    foreach (var (ownedCompanyName, percentage) in company.OwnedCompanies)
    {
        var ownedCompanyIndex = list.FindIndex(c => c.Name == ownedCompanyName);
        ownership[i, ownedCompanyIndex] = percentage;
    }
}

var M = Matrix<double>.Build.DenseOfArray(ownership);
var I = Matrix<double>.Build.DenseIdentity(M.RowCount);

var T = M * (I - M).Inverse();

Console.WriteLine("Real owned shares:");
for (var i = 0; i < T.RowCount; i++)
{
    Console.Write($"{list[i].Name}\t");
    for (var j = 0; j < T.ColumnCount; j++)
    {
        Console.Write($"{list[j].Name}: {T[i, j] * 100:F2}%\t");
    }
    Console.WriteLine();
}