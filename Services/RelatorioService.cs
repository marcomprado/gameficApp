using System.Collections.Generic;
using System.IO;
using GamificacaoApp.Models;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace GamificacaoApp.Services
{
    public class RelatorioService
    {
        public void ExportarRelatorio(List<Gameficacao> dados, List<Funcionario> funcionarios, string caminhoArquivo)
        {
            //Declaração da licença SQL
            ExcelPackage.License.SetNonCommercialPersonal("Patrick Patricio da Cunha");
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Relatório");

                // Cabeçalho
                ws.Cells[1, 1].Value = "Funcionário";
                ws.Cells[1, 2].Value = "Pontos";

                int row = 2;
                foreach (var item in dados)
                {
                    var funcionario = funcionarios.Find(f => f.Id == item.FuncionarioId);
                    string nomeFuncionario = funcionario != null ? funcionario.Nome : "Desconhecido";

                    ws.Cells[row, 1].Value = nomeFuncionario;
                    ws.Cells[row, 2].Value = item.Pontos;
                    row++;
                }

                // Ajusta largura das colunas automaticamente
                ws.Cells[ws.Dimension.Address].AutoFitColumns();

                // Criar gráfico de colunas
                var chart = ws.Drawings.AddChart("chart", eChartType.ColumnClustered) as ExcelBarChart;
                chart.Title.Text = "Pontuação por Funcionário";
                chart.SetPosition(1, 0, 3, 0);
                chart.SetSize(600, 400);

                // Adiciona a série (Valores, Categorias)
                var series = chart.Series.Add(
                    ws.Cells[2, 2, row - 1, 2], // Valores (Pontos)
                    ws.Cells[2, 1, row - 1, 1]  // Categorias (Funcionário)
                );
                series.Header = "Pontos";

                // Salva o arquivo
                package.SaveAs(new FileInfo(caminhoArquivo));
            }
        }
    }
}
