using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.Migrations
{
    public partial class PopularProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Produtos
                                    (Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl,
		                           ImagemThumbnailUrl, ProdutoDestaque, EmEstoque, CategoriaId)
                                 VALUES
                                   ('Mouse Pad', 'Mouse Pad Warrior Gamer'
		                           , 'Mouse Pad Warrior Gamer, Feito de EVA 3mm de alta densidade, estampa em tecido super macio, cor azul'
                                   ,50.00 ,'https://davidsonbss.000webhostapp.com/Content/mouse-pad.png'
                                   ,'https://davidsonbss.000webhostapp.com/Content/mouse-pad-min.png'
                                   ,1 , 1, 2)");

            migrationBuilder.Sql(@"INSERT INTO Produtos
                                   (Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl,
		                           ImagemThumbnailUrl, ProdutoDestaque, EmEstoque, CategoriaId)
                                 VALUES
                                   ('Notebook Acer', 'Notebook Acer Aspire G540'
		                           , 'Notebook Acer Aspire G540, Notebook Games com Core i5 de 10th geração 10600U, 8GB de memória RAM, SSD NVME M.2 de 250 GB, Placa de vídeo GTX 1660'
                                   ,4250.90 ,'https://davidsonbss.000webhostapp.com/Content/notebook.png'
                                   ,'https://davidsonbss.000webhostapp.com/Content/notebook-min.png'
                                   ,1 , 1, 2)");

            migrationBuilder.Sql(@"INSERT INTO Produtos
                                   (Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl,
		                           ImagemThumbnailUrl, ProdutoDestaque, EmEstoque, CategoriaId)
                                VALUES
                                   ('SSD Kingstom 400A', 'SSD Kingstom 400A 240GB SATA 2.5\""'
		                           , 'SSD Kingstom 400A, 240GB de armazenamento, Conector SATA, velocidade de leitura 500 Mbps e escrita 420 Mbps, Padrão Sata'
                                   ,250.90 ,'https://davidsonbss.000webhostapp.com/Content/ssd.png'
                                   ,'https://davidsonbss.000webhostapp.com/Content/ssd-min.png'
                                   ,0 , 1, 2)
                        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produto");

        }
    }
}
