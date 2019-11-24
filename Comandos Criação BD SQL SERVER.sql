Create table tblEmpregado(            
EmpregadoId int IDENTITY(1,1) NOT NULL,            
Nome varchar(20) NOT NULL,            
Cidade varchar(20) NOT NULL,            
Departamento varchar(20) NOT NULL,            
Genero varchar(10) NOT NULL        
)

Create procedure spAddEmpregado         (            
@Nome VARCHAR(20),             
@Cidade VARCHAR(20),            
@Departamento VARCHAR(20),            
@Genero VARCHAR(6)        )        as         Begin             Insert into tblEmpregado (Nome,Cidade,Departamento, Genero)             Values (@Nome,@Cidade,@Departamento, @Genero)         End

Create procedure spUpdateEmpregado          (             
@EmpId INTEGER ,           
@Nome VARCHAR(20),            
@Cidade VARCHAR(20),           
@Departamento VARCHAR(20),           
@Genero VARCHAR(6)        )          as          begin             Update tblEmpregado              set Nome=@Nome,             Cidade=@Cidade,             Departamento=@Departamento,           Genero=@Genero             where EmpregadoId=@EmpId          End

Create procedure spDeleteEmpregado         (             @EmpId int          )          as           begin             Delete from tblEmpregado where EmpregadoId=@EmpId          End

Create procedure spGetAllEmpregado      as      Begin          select *          from tblEmpregado       order by EmpregadoId End
