----rotina para amanha dia 02-08-2021

criar os registros corretos nas tabelas do sistema
para execucacao do capturardistribuicao para o 
tribunal do rio de janeiro

https://html-agility-pack.net/

---
http://www4.tjrj.jus.br/consultaProcessoWebV2/consultaProc.do?v=2&FLAGNOME=&back=1&tipoConsulta=publica&numProcesso=0000006-13.2021.8.19.0213

atentar para tabelas:

SolicitacaoCaptura
Processo
Instanciatribunal
TribunalJustica
ForumFaixaNumeroProcesso
forumFaixaAno

select IdTribunal,
       IdTecnologiaSite,
	   CapturarDado
  from EquipamentoProcessamentoTribunal
where IdEquipamentoProcessamento = 26
and Ativo = 1

select * from SolicitacaoCaptura where id in (1382)

select top 1 * from Processo where IdSolicitacaoCaptura = 1382

select * from InstanciaTribunal where id = 5302

select * from ForumFaixaNumeroProcesso where id in (5314)

select * from ForumTribunal where id in (3770)

select * from ForumFaixaNumeroAno where IdForumFaixaNumeroProcesso = 5314 and Ano = 2021

delete from ProcessamentoCaptura where IdSolicitacaoCaptura = 1382 and DataTermino is null

--- querys auxiliares

--- select para pegar solicitacaocaptura

select sc.Id,
       sc.Descricao,
	   sc.IdStatus,
	   sc.CapturarDado,
	   sc.CapturarDistribuicao,
	   sc.DataTerminoUltimaCaptura,
	   sc.DataUltimoProcessamento
  from SolicitacaoCaptura sc
 where sc.IdStatus in (3,12,4)
   and (sc.IdEquipamentoProcessamento = 26 or sc.IdEquipamentoProcessamento is null)
   and not exists (select pc.IdSolicitacaoCaptura from ProcessamentoCaptura pc where pc.IdSolicitacaoCaptura = sc.id and pc.DataTermino is null)
   and sc.Id in (select p.IdSolicitacaoCaptura from Processo p where p.IdSolicitacaoCaptura = sc.id and p.IdTribunalJustica = 2 
                 and p.IdTecnologiaSite = 2 and (p.IdStatus = 1 or p.IdStatus = 10))

---



---- insert na solicitacaocaptura

status solicitacaocaptura --> 3 Liberado processamento.

insert into SolicitacaoCaptura values (GETDATE(),1,'Captura Distribuição - TJRJ - 0038 - 0800000 - MAQ. 26',0,3,null,0,1,0,0,0,1,1,0,0,null,null,null)

--- primeiro campo refere-se ao id da solicitacaocaptura gerado no insert acima
insert into Processo values (8841,'9999999-00.2021.8.19.0038',2,null,1,1,null,5319,20,
null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,
8559,0,null,0,null)


select top 100 
       p.Numero, 
	   p.IdSolicitacaoCaptura, 
	   p.IdFaixaNumeroProcesso,
       p.IdTribunalJustica,
	   p.IdTecnologiaSite, 
	   p.IdInstanciaTribunal,
	   ffnp.IdInstanciaTribunal
  from Processo p
  join ForumFaixaNumeroProcesso ffnp on ffnp.id = p.IdFaixaNumeroProcesso
where p.Numero like ('9999%')
and p.IdTribunalJustica = 5008
order by p.id desc

select top 100 *
  from SolicitacaoCaptura
order by id desc

select top 100 * 
  from Processo p
order by id desc


select top 20 
       p.Numero, 
	   p.IdSolicitacaoCaptura, 
	   p.IdTribunalJustica, 
	   p.IdFaixaNumeroProcesso,
	   p.IdInstanciaTribunal,
	   ffnp.IdInstanciaTribunal
  from Processo p
  join ForumFaixaNumeroProcesso ffnp on ffnp.id = p.IdFaixaNumeroProcesso
--where p.Numero like ('9999%')
  where p.IdSolicitacaoCaptura = 1379
order by p.id desc 
 

--delete
--   from ProcessamentoCaptura 
--  where idEquipamentoProcessamento = 26 
----order by id desc
-- and DataTermino is null


select *
  from ForumFaixaNumeroProcesso
where id = 5310


select top 100 *
  from ForumFaixaNumeroAno
--order by id desc
where IdForumFaixaNumeroProcesso = 5310



select * from InstanciaTribunal
where url like 'https://tjrj.pje.jus.br/1%'


select * from TecnologiaSite


select count(*) from Processo


select count(*) from HistoricoStatusProcesso



select * from InstanciaTribunal
where url like 'https://tjrj.pje.jus.br/1%'
or url like 'https://sistemas.tjes.jus.br%'









select top 100 *
  from SolicitacaoCaptura
where id in 
(8848,
8846,
8845,
8844,
8843,
8842,
8841,
8839,
8838,
8837,
8836,
8835,
8834,
8833,
8832,
8831,
8830)
order by id desc



select * 
  from Processo p
where p.IdSolicitacaoCaptura in 
(8848,
8846,
8845,
8844,
8843,
8842,
8841,
8839,
8838,
8837,
8836,
8835,
8834,
8833,
8832,
8831,
8830)
order by id asc

select top 100 
       p.Numero, 
	   p.IdSolicitacaoCaptura, 
	   p.IdFaixaNumeroProcesso,
       p.IdTribunalJustica,
	   p.IdTecnologiaSite, 
	   p.IdInstanciaTribunal,
	   ffnp.IdInstanciaTribunal
  from Processo p
  join ForumFaixaNumeroProcesso ffnp on ffnp.id = p.IdFaixaNumeroProcesso
where p.Numero like ('9999%')
and p.IdTribunalJustica = 5008
order by p.id desc


select * 
  from ForumFaixaNumeroProcesso
where id in 
(5730,
8627,
8626,
8625,
8624,
5057,
8623,
8616,
8622,
8621,
8620,
8619,
8618,
8617,
6588,
6200,
6126,
5902,
5821,
5736)

select top 100 *
  from ForumFaixaNumeroAno
where IdForumFaixaNumeroProcesso in
(5730,
8627,
8626,
8625,
8624,
5057,
8623,
8616,
8622,
8621,
8620,
8619,
8618,
8617,
6588,
6200,
6126,
5902,
5821,
5736)
order by id desc


--9999999-00.2021.8.19.0012


select * from InstanciaTribunal
where url like 'https://tjrj.pje.jus.br/1%'
or url like 'https://sistemas.tjes.jus.br%'


select * from TecnologiaSite


select count(*) from Processo


C:\Pastas de Trabalho\Projetos\Processos\usuariosistema@usuariosistema.com.br\Solicitacao000001380\Processos\08157574720218190038


https://sistemas.tjes.jus.br/pje/login.seam

C:\Pastas de Trabalho\Projetos\Processos\usuariosistema@usuariosistema.com.br\Solicitacao000001379\Processos\50068325820218080024\Desmembramento


























