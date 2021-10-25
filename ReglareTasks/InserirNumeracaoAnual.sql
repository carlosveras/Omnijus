--=====================================================
-- Configurar Numeração para o Ano
--=====================================================
declare @Forum varchar(4);
declare @Numeracao varchar(7);
declare @ano int;
declare @identificacaoProcesso varchar(10);
declare @ultimonumero int;
declare @IdForumFaixaNumeroProcesso int;
--=====================================================

select @identificacaoProcesso = '5.02'
select @Numeracao = '1000000'
select @ano = 2020

select @Forum = '0707';
select @ultimonumero = 0100546 - 2;


select ft.id as IdForumTribunal
		,ft.Numero as NumeroForum
		,ft.Nome as NomeForum
		,ffnp.id as IdForumFaixaNumeroProcesso
		,ffnp.FaixaNumeroProcesso
		,ffna.Ano
		,ffna.UltimoNumeroProcesso
  from ForumFaixaNumeroAno ffna
		,ForumFaixaNumeroProcesso ffnp
		,ForumTribunal ft
		,TribunalJustica tf
where ffna.IdForumFaixaNumeroProcesso = ffnp.Id
and ffnp.IdForumTribunal = ft.Id
and ft.IdTribunal = tf.Id
and tf.IdentificacaoProcesso = @identificacaoProcesso
and ft.numero = @Forum
and ffnp.FaixaNumeroProcesso = @Numeracao
and ffna.Ano = @ano
order by  ft.Numero, ffnp.FaixaNumeroProcesso



--=========================================
select @IdForumFaixaNumeroProcesso = ffnp.id
  from ForumFaixaNumeroProcesso ffnp
		,ForumTribunal ft
		,TribunalJustica tf
where ffnp.IdForumTribunal = ft.Id
and ft.IdTribunal = tf.Id
and tf.IdentificacaoProcesso = @identificacaoProcesso
and ft.numero = @Forum
and ffnp.FaixaNumeroProcesso = @Numeracao
order by  ft.Numero, ffnp.FaixaNumeroProcesso
--=========================================


--=================================
if (@IdForumFaixaNumeroProcesso is null)
	begin 
		select 'Sem Faixa de Numeração do Fórum'
	end
else
    begin
		if (select count(1) from ForumFaixaNumeroAno where IdForumFaixaNumeroProcesso = @IdForumFaixaNumeroProcesso and ano = @ano) = 0
		   begin
				insert into ForumFaixaNumeroAno values (getdate(),1,null,null,@IdForumFaixaNumeroProcesso,@ano,@ultimonumero)
		   end
		else
		   begin
			  select 'Já tem'
		   end
	end

--insert into ForumFaixaNumeroAno values (getdate(),1,null,null,3591,2020,0100540)






