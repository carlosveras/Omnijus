begin transaction;

declare @descricao varchaR(100);
declare @Forum varchar(4);
declare @Numeracao varchar(7);
declare @IdEquipamentoProcessamento int;
declare @IdSolicitacao int;
declare @NumeroProcesso varchar(25);
declare @IdFaixaNumeracao int;
declare @idtribunal int;
declare @idInstanciaTribunal int;
declare @siglaTribunal varchar(10);
declare @identificacaoProcesso varchar(10);
declare @IdTecnologiaSite int;
declare @ano int;
declare @idForum int;
declare @ultimoNumeroFaixa int;

--===================================================================================================
-- Configura as variaveis de Acordo com o Numero do Processo que será gerado o intervalo
--===================================================================================================
select @identificacaoProcesso = '8.19'
select @ano = 2021;
select @IdTecnologiaSite = 20;  
select @Numeracao = '0800000';
select @ultimoNumeroFaixa = 0800146;
select @Forum = '0208';
--===================================================================================================

select @idtribunal = id , @siglaTribunal = Sigla
   from TribunalJustica
where IdentificacaoProcesso = @identificacaoProcesso;

select @idInstanciaTribunal = id 
		--,@IdTecnologiaSite = IdTecnologiaSite
   from InstanciaTribunal
where IdTribunal = @idtribunal
and Descricao in ('1ª e 2ª Instância', '1ª instância','1ª Instância')
and (@IdTecnologiaSite is null or @IdTecnologiaSite = IdTecnologiaSite);

select @idForum = id 
   from ForumTribunal ft
where ft.IdTribunal = @idtribunal
and ft.Numero = @Forum;


--===================================================================================================
--Incluir a Faixa de Numerçao
--===================================================================================================
insert into ForumFaixaNumeroProcesso (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdForumTribunal
							,QuantidadeProcessoPendente,Ativo,QuantidadeProcessoNaoLocalizado,FaixaNumeroProcesso
							,IdInstanciaTribunal,QuantidadeRepeticaoProcessamento,QuantidadeDiaRetrocessoPesquisa)
values (getdate(),1,null,null,@idForum,1,1,1,@Numeracao,@idInstanciaTribunal,1,3);

select @IdFaixaNumeracao = @@IDENTITY;
--===================================================================================================

--===================================================================================================
--Incluir a Faixa de Numerçao no Ano
--===================================================================================================
insert into ForumFaixaNumeroAno (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdForumFaixaNumeroProcesso,Ano,UltimoNumeroProcesso)
values (getdate(),1,null,null,@IdFaixaNumeracao,@ano,@ultimoNumeroFaixa);
--===================================================================================================

--===================================================================================================
--Incluir a Solicitação de Captura
--===================================================================================================
select @descricao = 'Captura Distribuição - ' + @siglaTribunal + ' - ' + @Forum + ' - ' + @Numeracao;

insert into SolicitacaoCaptura values
(getdate(),1,@descricao,1,3,null,0,1,0,0,0,1,1,0,0,null,null,null)

select @IdSolicitacao = @@IDENTITY;
--===================================================================================================
select @NumeroProcesso = '9999999-00.' + convert(varchar(4),@ano) + '.' + @identificacaoProcesso + '.' + @Forum;

insert into Processo (IdSolicitacaoCaptura,Numero,IdTribunalJustica,IdStatus,Eletronico,IdTecnologiaSite,IdFaixaNumeroProcesso, IdInstanciaTribunal, justicagratuita)
values (@IdSolicitacao,@NumeroProcesso,@idtribunal,1,1,@IdTecnologiaSite,@IdFaixaNumeracao, @idInstanciaTribunal, 0)
--===================================================================================================

--rollback transaction;
commit transaction;