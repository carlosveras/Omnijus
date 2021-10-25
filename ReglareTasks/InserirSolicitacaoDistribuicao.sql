--=====================================================
-- Configurar Solicitação para Forum
--=====================================================
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

--=====================================================
-- Ajustar Variaveis
--=====================================================
select @identificacaoProcesso = '5.01'
select @Forum = '0040';
select @Numeracao = '0100000'
--select @IdEquipamentoProcessamento = null;
--select @idtribunal = 5022
--select @idInstanciaTribunal = 5282
--=====================================================


--=====================================================
-- Ajustar Variaveis
--=====================================================
select @idtribunal = id , @siglaTribunal = Sigla
   from TribunalJustica
where IdentificacaoProcesso = @identificacaoProcesso
--=====================================================

--=====================================================
-- Ajustar Variaveis
--=====================================================
select @idInstanciaTribunal = id 
   from InstanciaTribunal
where IdTribunal = @idtribunal
and Descricao = '1ª e 2ª Instância'
--=====================================================


--=====================================================
-- Ajustar Variaveis
--=====================================================
select @IdFaixaNumeracao = ffn.Id
	from ForumFaixaNumeroProcesso ffn
		,forumtribunal ft
where ffn.FaixaNumeroProcesso = @Numeracao
and ffn.idforumtribunal = ft.id
and ft.numero = @Forum
and ft.idtribunal  = @idtribunal
--=====================================================


select @descricao = 'Captura Distribuição - ' + @siglaTribunal + ' - ' + @Forum + ' - ' + @Numeracao
select @NumeroProcesso = '9999999-00.2020.' + @identificacaoProcesso + '.' + @Forum;

insert into SolicitacaoCaptura (CriadoEm,CriadoPor,Descricao,QuantidadeProcessos,IdStatus,
								IdEquipamentoProcessamento,BaixarCopia,CapturarDado,CapturarMovimento,CapturarSituacao
								,CapturarJulgamento,CapturarDistribuicao,CapturarPartes,CapturarAudiencia,VerificarAdvogado)
			values (GETDATE(),1,@descricao,1,3,@IdEquipamentoProcessamento,0,1,0,0,0,1,1,0,0)


select @IdSolicitacao = @@IDENTITY;

insert into Processo (IdSolicitacaoCaptura,Numero,IdTribunalJustica,IdStatus,Eletronico,IdTecnologiaSite,IdFaixaNumeroProcesso, IdInstanciaTribunal, justicagratuita)
values (@IdSolicitacao,@NumeroProcesso,@idtribunal,1,1,17,@IdFaixaNumeracao, @idInstanciaTribunal, 0)


