# RestApi_Imobiliaria
api que trata da comunicação entre o aplicativo Imobiliaria e o banco de dados do mesmo


no ultimo commit, do projeto RestApi_imobiliaria, foi modificado as models do projeto para assim, tambem atravéz do metodo “Code First” no EF core , fosse reconstruido a base de dados do projeto, onde foi retirado dos campos varchar  da tabela locatarios, os limites de caracteres que pudim ser armazenado em cada campo,  e remover a chave extrangeira, pra ficar mais facil testar as tabelas do projeto, pra facilitar a correção de alguns bugs 


Criar projeto webApi para o app santos imobiliarria:

criar a pasta do projeto, abrila no vscode, acessa-la pelo terminal do vscode e no terminal executar o seguinte comando:

dotnet new webapi –no-https

projeto criado: eliminar os seguintes arquivos do projeto nas seguintes pastas
controllers/weatherForecastController.cs
pastaDoProjeto/weatherForecast.cs

configurar o projeto para aceitar requisição de outro dominio


No arquivo Startup.cs:

no metodo configurreService(), acrescentar service.AddCors();  antes do fim do metodo

no metodo configure(), antes de app.UseRouting(), acrescentar:
app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod())

ficara assim:

![imagensDoprojeto_restWeb_api](https://user-images.githubusercontent.com/106206316/221329161-42acf146-b2f8-4154-91f6-275c1cddb13c.png)


	

Proximo passo: Preparar o projeto para trabalhar com EF core,  EntityFrameWorkCore

### 1  dotnet tool install --global dotnet-ef --version 3.0.0 
### 2 dotnet add package Pomelo.EntityFrameworkCore.MySql --version 3.0.0
### 3 dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.0.0 
### 4 dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 3.0.0
### 5 dotnet add package SeriLog.Extensions.Logging.File
### 6 dotnet add package Microsoft.EntityFrameworkCore.Tools  --version 3.0.0

próximo passo: 

criar as models, pois é ela que o EF core, usara para implementar as migrations para poder criar o DB, no modo code First

Criar as classes de modelagens de dados:
1 Imoveis.cs
2 Locatarios.cs

 # Criar a migrations para criar o DB: 
### dotnet ef migrations add CreateDatabase
# comando que executa a criação do DB, apartir dos dados da migration
### dotnet ef database update 



Script das tabelas do DB
CREATE TABLE `imoveis` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `tipoImovel` varchar(64) CHARACTER SET utf8mb4 NULL,
    `enderecoImovel` varchar(64) CHARACTER SET utf8mb4 NULL,
    `finalidadeImovel` varchar(64) CHARACTER SET utf8mb4 NULL,
    `descricaoImovel` varchar(64) CHARACTER SET utf8mb4 NULL,
    `precoImovel` DECIMAL(5,2) NOT NULL,
    CONSTRAINT `PK_imoveis` PRIMARY KEY (`Id`)
);

CREATE TABLE `locatarios` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `nomeLocatario` varchar(64) CHARACTER SET utf8mb4 NULL,
    `cpfLocatario` varchar(64) CHARACTER SET utf8mb4 NULL,
    `dataNascLocatario` varchar(64) CHARACTER SET utf8mb4 NULL,
    `dataLocLocatario` varchar(64) CHARACTER SET utf8mb4 NULL,
    `dataVencimentoAlugLocatario` varchar(64) CHARACTER SET utf8mb4 NULL,
    `ImovelId` int NOT NULL,
    `ImoveisId` int NULL,
    CONSTRAINT `PK_locatarios` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_locatarios_imoveis_ImoveisId` FOREIGN KEY (`ImoveisId`) REFERENCES `imoveis` (`Id`) ON DELETE RESTRICT  
);

popular as tabelas para teste:
INSERT INTO  imoveis(    
tipoImovel,
enderecoImovel,
finalidadeImovel,
descricaoImovel,
precoImovel
)VALUES('casa','rua luar do sertao','alugar','casa amarela',100.000);

INSERT INTO  locatarios(    
nomeLocatario,cpfLocatario,
dataNascLocatario,
dataLocLocatario,
dataVencimentoAlugLocatario,
ImovelId
)VALUES('jairo','28166655598','24/11/1979','10/02/2023','5° dia util de cada mes',1);


Para implementar as funcionalidades da nossa api, de forma que ela faça requisições no nosso DB e tambem possa persistir dados no nosso DB, precisamos criar nossa conexão com o banco de dados, que simbolicamente é chamado de contexto de banco de dados , ou Dbcontext.

Contexto de DB:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_ImobiliariaSantos.Models
{
    public class ContextoDataBase:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;DataBase=ImobiliariaSantos;Uid=root;Pwd=;");
        }

        public DbSet <Imoveis> imoveis{get;set;}
        public DbSet <Locatarios> locatarios{get;set;}
        
    }
}









criar as classes com os metodos onde sera implementada as ações para os objetos , que instanciaremos, das classes Imoveis e Locatarios:

Serciço Locatarios:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_ImobiliariaSantos.Models
{
    public class LocatarioServices
    {
         public Locatarios CadastrarLocatario(Locatarios novoLocatario)
        {
            using(var contexto = new ContextoDataBase())
            {
                contexto.Add(novoLocatario);
                contexto.SaveChanges();
                return novoLocatario;
            }
            }
         public List<Locatarios> ListarLocatarios()
        {
            using(var contexto = new ContextoDataBase())
            {
                return contexto.locatarios.ToList<Locatarios>();
            }
        }
        
    }
}










serviços Imoveis:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_ImobiliariaSantos.Models
{
    public class ImoveLServices
    {
          public Imoveis CadastrarImovel(Imoveis novoImovel)
        {
            using(var contexto = new ContextoDataBase())
            {
                contexto.Add(novoImovel);
                contexto.SaveChanges();
                return novoImovel;
            }
        }

         public List<Imoveis> ListarImoveis()
        {
            using(var contexto = new ContextoDataBase())
            {
                return contexto.imoveis.ToList<Imoveis>();
            }
        }
        
        
    }
}





















Criar as rotas, que vai intermedia a comunicação entre a nossa Api e o nossos serviços

Controllers:

Controller Locatario:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_ImobiliariaSantos.Models;

namespace WebAPI_ImobiliariaSantos.Controllers
{
    [ApiController]
    [Route("/WebAPI_ImobiliariaSantos/api/[controller]")]
    public class LocatariosController : ControllerBase
    {

        public IActionResult Cadastra(Locatarios locatarios)
        {
            if (!ModelState.IsValid) // faz validação no parametro recebido, nesse  caso, ele faz validação em "Imoveis imoveis"
                return BadRequest(ModelState);

            LocatarioServices lc = new LocatarioServices();
            lc.CadastrarLocatario(locatarios);
            return Ok(locatarios);
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                LocatarioServices Ls = new LocatarioServices();
                List<Locatarios> locatarios = Ls.ListarLocatarios();
                return Ok(locatarios);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha ao processar dados");
            }
        }
   }
}






Controller Imoveis:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_ImobiliariaSantos.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI_ImobiliariaSantos.Controllers
{


    [ApiController]
    [Route("/WebAPI_ImobiliariaSantos/api/[controller]")]

    public class ImoveisController:ControllerBase
    {
        

     [HttpPost]
public IActionResult Cadastra(Imoveis imoveis)
{
    if(!ModelState.IsValid) // faz validação no parametro recebido, nesse  caso, ele faz validação em "Imoveis imoveis"
        return BadRequest(ModelState);

    ImoveLServices Im = new ImoveLServices();
    Im.CadastrarImovel(imoveis);
    return Ok(imoveis);
    
}

[HttpGet]
public IActionResult ListarTodos()
{
    try{
        ImoveLServices Im = new ImoveLServices();
        List<Imoveis> imoveis = Im.ListarImoveis();
        return Ok(imoveis);
    }
    catch(Exception)
    {
        return StatusCode(500, "Falha ao processar dados");
    }
}
        
    }
}





link para teste no postman:

http://localhost:5000/WebAPI_ImobiliariaSantos/api/imoveis 

http://localhost:5000/WebAPI_ImobiliariaSantos/api/locatarios 

