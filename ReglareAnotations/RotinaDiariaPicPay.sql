
http://dashboard.omnijus.com.br:3000/d/2341bDBMzA/omnijus-operacional-producao?orgId=1&refresh=1h
login: carlos.silva
senha: Mudar@123


<---- Maquinas Ativas para captura e processamento PICPAY ---->

33 --172.13.0.14 

34 --172.13.0.15 

35 --172.13.0.16 

<----- Rotina diaria PicPay --------->

1-Realizar captura com robo da maquina 34 -- 172.13.0.15

2-Pegar email do dia anterior, este e-mail chega em torno das 8:00hrs
  e conferir os processos da planilha com o que capturamos.
  utilizar a query abaixo:

select pro.id as idprocesso
		,ttp.Numero
		,pro.IdStatus 
		,ttp.CriadoEm
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 15) as DMB
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 5)  as DPZ
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 21) as ITG
        ,pro.Forum
		,pro.Vara
		,pro.Comarca
		,pro.OrgaoJulgador
  from TermoTribunalProcesso ttp
		,Processo pro
where ttp.Numero = pro.Numero
and ttp.IdSolicitacaoCaptura = pro.IdSolicitacaoCaptura
and ttp.NomeParte like 'PIC%'
and ttp.CriadoEm >= '2021-10-01 00:00:00'
and pro.Numero in 
('5012433-81.2021.8.08.0012',
'5027969-96.2021.8.08.0024',
'5018841-77.2021.8.08.0048')
order by ttp.CriadoEm desc

3- Rodar a query abaixo e se certificar 
   que so retornem status 2.
   Se retornar registro com status 10, 
   basta rodar na maquina final 15 ou na 16 a rotina 
   CapturarProcesso.
   
   select sc.Descricao,
		pro.IdSolicitacaoCaptura, 
		pro.IdStatus, 
		count(1) as qutdade
  from processo pro
		,SolicitacaoCaptura sc
where pro.IdSolicitacaoCaptura in (8764,8866,8765,8867,8868,8840,8869,8870,8881,8882,8883)
and pro.IdSolicitacaoCaptura = sc.Id
and pro.IdStatus != 9
group by sc.Descricao, pro.IdSolicitacaoCaptura, pro.IdStatus
order by sc.Descricao,pro.IdSolicitacaoCaptura, pro.IdStatus

4- Apos o passo 3 executar o processo:
   DisponibilizarMovimentacao na VM 172.13.0.16 ou se 
   esta maquina estiver down executar na maquina local 
   apontando a connection string para o banco de 
   producao.






5- Antes de executar o disponibilizarDistribuicao, verificar se 
   forum, vara e comarca estao com a nomeclatura certa com base
   no campo orgaojulgador, utilizar a query abaixo:

select pro.id as idprocesso
		,ttp.Numero
		,pro.IdStatus 
		,ttp.CriadoEm
		,pro.IdSolicitacaoCaptura
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 15) as DMB
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 5)  as DPZ
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 21) as ITG
        ,pro.Forum
		,pro.Vara
		,pro.Comarca
		,pro.OrgaoJulgador
  from TermoTribunalProcesso ttp
		,Processo pro
where ttp.Numero = pro.Numero
and ttp.IdSolicitacaoCaptura = pro.IdSolicitacaoCaptura
and ttp.NomeParte like 'PIC%'
and ttp.CriadoEm >= '2021-11-01 00:00:00'
and (select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 21) = 0
order by ttp.CriadoEm desc


<---- Query para encontrar anteriores para correcao  de forum vara e comarca -->

select top 100 
         p.id
		,p.Numero
        ,p.Forum
		,p.Vara
		,p.Comarca
		,p.OrgaoJulgador
  from Processo p
 where p.OrgaoJulgador = '1º Juizado Especial Cível da Regional de Alcântara'
order by id desc

Vitória - Comarca da Capital - 9ª Vara Cível
<--- Para alterar os campos se necessario --->

begin transaction

update Processo
set 
	vara = '25º JUIZADO ESPECIAL CÍVEL'
	,forum = 'PAVUNA'
	,comarca = 'CAPITAL'
where id = 1889200

commit transaction

6- TIRAR OS ESPACOS EM BRANCO DO FORUM VARA E COMARCA

begin transaction
update processo
   set vara = trim(vara)
		,forum = trim(forum)
		,comarca = trim(comarca)
where numero in (
(
'0800577-81.2021.8.19.0202',
'0801186-61.2021.8.19.0203',
'5007309-63.2021.8.08.0030',
'0807631-14.2021.8.19.0036')
commit transaction

----- MONITORAMENTO APOS EMAIL DAS 13:00 HRS

----- incluir processo no monitoramento
-- com base em email recebido entre 13:00 
--===============================================
-- Cria a tabela temporario de trabalho
--===============================================
create table #ativoOmnijus (numero varchar(30), IdSolicitacaoCaptura int)
--===============================================

--===============================================
-- Insere os processos que precisam ser monitorados
-- na tabela temporaria
--===============================================
insert into #ativoOmnijus (numero) values
('5001663-12.2021.8.08.0050'),
('0801505-90.2021.8.19.0021'),
('5004125-74.2021.8.08.0006'),
('0022649-83.2021.8.19.0206'),

0804656-64.2021.8.19.0021
5001144-98.2021.8.08.0062


--===============================================

--===============================================
-- Atualiza os processos já existentes no Monitoramento
--===============================================
update #ativoOmnijus
   set IdSolicitacaoCaptura = 
            (select distinct min(sc.id)
                        from SolicitacaoCaptura sc
                        ,processo pro
                        where sc.Descricao like 'cap%mov%tj%Pic%'
                        and SUBSTRING(#ativoOmnijus.numero,17,4) = SUBSTRING(pro.numero,17,4)
                        and SUBSTRING(#ativoOmnijus.numero,1,2) = SUBSTRING(pro.numero,1,2)
                        and pro.IdSolicitacaoCaptura = sc.Id)
--===============================================

--===============================================
-- Deleta os processos já existentes no Monitoramento
--==============================================
delete #ativoOmnijus
   where exists (select 1
                    from processo pro 
                        ,SolicitacaoCaptura sc
                    where sc.Descricao like 'cap%mov%tj%Pic%'
                    and pro.IdSolicitacaoCaptura  = sc.id
                    and #ativoOmnijus.numero = pro.numero)
--==============================================

--===============================================
-- Insere os Processos no Monitoramento
--==============================================
insert into Processo (IdSolicitacaoCaptura,
                            Numero,
                            IdTribunalJustica,
                            IdStatus,
                            Eletronico,
                            IdTecnologiaSite,
                            IdInstanciaTribunal, 
                            justicagratuita)
select distinct a.IdSolicitacaoCaptura
        ,a.numero
        ,pro.IdTribunalJustica
        ,1
        ,1
        ,pro.IdTecnologiaSite
        ,pro.IdInstanciaTribunal
        ,0
    from #ativoOmnijus a
        ,processo pro
where a.IdSolicitacaoCaptura = pro.IdSolicitacaoCaptura
and pro.id = (select min(pro1.id)
                from processo pro1
                where pro1.IdSolicitacaoCaptura = a.IdSolicitacaoCaptura)
--==============================================

drop table #ativoOmnijus
--==============================================

--======= QUERY PARA LEVANTAR FORUM VARA E COMARCA CORRIGIDOS
--======= ANTERIORMENTE

select top 1000 
        p.id		
	   ,p.Numero
	   ,p.IdStatus
	   ,p.Vara
	   ,p.Forum
	   ,p.Comarca
       ,p.OrgaoJulgador
  from Processo p
 where p.OrgaoJulgador like '%Ilha do Governador%'
    or p.OrgaoJulgador like '%São Gonçalo%'
 order by id desc
 
 
<------ PARA CAPTURAR PROCESSO TJRJ PROPRIO --------->

<----- Capturar TJRJ Proprio -------->

colocar linha abaixo nas propriedades da solution
CapturarDistribuicao
"Captura Distribuição - TJRJ - Generico"

'0311783-73.2021.8.19.0001'
 
--====== QUERY GERA PROCESSOS GENERICOS TJRJ SQL

--select * from SolicitacaoCaptura where id = 8863
--"Captura Distribuição - TJRJ - Generico"

drop table #CapturaTJRJ

create table #CapturaTJRJ (numero varchar(30))

insert into #CapturaTJRJ (numero) values
('0031550-28.2021.8.19.0210')

insert into Processo (IdSolicitacaoCaptura,
						Numero,
						IdTribunalJustica,
						IdStatus,
						Eletronico,
						IdTecnologiaSite,
						IdInstanciaTribunal, 
						justicagratuita)
select 8863
		,a.numero
		,2
		,1
		,1
		,2
		,5302
		,0
	from #CapturaTJRJ a
	where not exists (select 1
						from processo pro
						where pro.IdSolicitacaoCaptura = 8863
						and pro.Numero = a.numero)

select *
  from processo
where IdSolicitacaoCaptura = 8863
and IdStatus not in (9,2)

select * from SolicitacaoCaptura where id = 8863

/*

update ProcessamentoCaptura
   set DataTermino = getdate()
where IdEquipamentoProcessamento = 39
and DataTermino is null


update EquipamentoProcessamento
   set Address = 'A463A1513F02'
where id = 39
--A463A1513F02

select * 
  from equipamentoprocessamentotribunal
where idequipamentoprocessamento = 39
and ativo = 1

select * 
  from equipamentoprocessamentotribunal
where idequipamentoprocessamento = 39
and idtribunal = 2

update equipamentoprocessamentotribunal set ativo = 1 where id = 3858

select *
  from solicitacaocaptura
where id = 8863
*/

<----- ROTINA PESQUISAR MOVIMENTACAO ------->

-===========================================================
-- Listar os Movimentos Localizados
--===========================================================
select pro.id as idprocesso
		,pro.Numero
		,pm.Id as idmovimento
		,pm.Data
		,pro.idEventoPrimeiroLista
		,pro.idEventoUltimoLista
		,pm.Descricao
		,sc.Descricao
		,pm.CriadoEm
		,pm.Integrado
		,pro.IdStatus
  from processo pro
	,SolicitacaoCaptura sc
	,ProcessoMovimento pm
where sc.Descricao like 'Captura Movimentação - % - Poc PicPay'
and sc.id = pro.IdSolicitacaoCaptura
and pm.Numero = pro.Numero
and pm.CriadoEm >= '2021-11-30 18:00:00'  --> Precisa Ajustar para o horário do ultimo Processamento.
--and pm.AlteradoEm >= '2021-11-27 00:00:00'
and pm.Integrado = 0
--and pro.numero = '0005388-08.2021.8.19.0206'
and pro.IdSolicitacaoCaptura in (8764,8866,8765,8867,8868,8840,8869,8870)
--and pro.numero in (
--'0800051-42.2021.8.19.0032',
--'0800072-78.2021.8.19.0206'
--)
--order by pm.Data, sc.Descricao, pm.id desc
--order by pro.Numero, pm.Data, sc.Descricao, pm.id desc
--and (pm.Data not like '%/11/%' and pm.Data not like '%/10/%')
--and pm.Data not like '%/11/%' 
order by pm.Data, pro.Numero, pm.CriadoEm



===============================================

select pm.Numero
      ,pm.Integrado
	  ,pm.Descricao
	  ,pm.CriadoEm
	  ,pm.AlteradoEm
	  ,p.IdSolicitacaoCaptura as IdSolicProcesso
	  ,pm.IdSolicitacaoCaptura as IdSolicMovimento
	  ,p.Id as IdNoProcesso
	  ,pm.IdProcesso as IdNoMovimento
 from ProcessoMovimento pm
 left join Processo p on p.Numero = pm.Numero
where cast(pm.CriadoEm AS DATE) = '2021-12-14'
--and pm.Integrado <> 1
--where p.IdSolicitacaoCaptura in  ( 8764, 8765,8840, 8866, 8867,8868 ,8869, 8870)
order by pm.AlteradoEm desc
--group by pm.Descricao, pm.Numero


/*
--=============================================
-- Ajusta a Maquina 21 para Processar
--=============================================
update EquipamentoProcessamentoTribunal
   set ativo = 0
where IdEquipamentoProcessamento = 39

update EquipamentoProcessamentoTribunal
   set ativo = 1
where IdEquipamentoProcessamento = 39
and IdTribunal in (5008,2)
and IdTecnologiaSite = 5
and ativo = 0

update EquipamentoProcessamentoTribunal
   set ativo = 1
where IdEquipamentoProcessamento = 39
and IdTribunal in (2)
and IdTecnologiaSite = 2
and ativo = 0
--=============================================

--===========================================
-- Limpa o Processamento da Maquina
--============================================
delete ProcessamentoCaptura
where IdEquipamentoProcessamento = 39
and DataTermino is null
--============================================

*/

--=============================================================
-- Incluir os processos que não estão em monitoramento
--=============================================================
--create table #novos (numeroprocesso varchar(30));

----insert into #novos values

--select * from #novos

--begin transaction

--insert into HistoricoStatusProcesso
--select pro.id
--		,getdate()
--		,1
--		,24
--		-- n.numeroprocesso
--  from #novos n
--	,processo pro
--	,SolicitacaoCaptura sc
--where n.numeroprocesso = pro.Numero
--and pro.IdSolicitacaoCaptura = sc.id
--and sc.Descricao like 'cap%distr%'
--and not exists (select 1
--				from HistoricoStatusProcesso hsp
--				where pro.id = hsp.IdProcesso
--					and hsp.IdStatus = 24)

--commit transaction
--=============================================================


--=============================================================
-- Ajusta para reprocessar as solicitações de Movimentações
--=============================================================
--begin transaction

--update processo
--   set IdStatus = 1, PossuiDocumento = 0  , IdEquipamentoProcessamento = null --, IdEventoAnterior = null, idEventoPrimeiroLista = null , idEventoUltimoLista = null
--from SolicitacaoCaptura sc
--where sc.id = processo.IdSolicitacaoCaptura
--and sc.Descricao like 'Captura Movimentação - % - Poc OmniJus'
--and sc.Id in (8849,8850)
--and processo.IdStatus in (2,9)

--delete  HistoricoStatusProcesso
--where IdProcesso in (select pro.id
--					  from Processo pro
--						,SolicitacaoCaptura sc
--					where sc.id = pro.IdSolicitacaoCaptura
--					and sc.Descricao like 'Captura Movimentação - % - Poc OmniJus'
--					and sc.Id in (8849,8850)
--					and pro.IdStatus = 1)

--delete ProcessoPeca
--    from processo prom
--             ,processo pro
--where prom.IdSolicitacaoCaptura in (8849,8850)
--and prom.IdStatus != 2
--and prom.numero = pro.Numero
--and prom.IdSolicitacaoCaptura != pro.IdSolicitacaoCaptura
--and ProcessoPeca.IdProcesso = pro.id


--commit transaction
--rollback transaction




--=========================================================
-- Inserir Novos Processo no Monitoramento do TJES - PJe
--=========================================================
--insert into Processo (IdSolicitacaoCaptura,Numero,IdTribunalJustica,IdStatus,Eletronico,IdTecnologiaSite,IdFaixaNumeroProcesso, IdInstanciaTribunal, justicagratuita)
--select 8764
--		,pro.Numero
--		,pro.IdTribunalJustica
--		,1
--		,pro.Eletronico
--		,5
--		,pro.IdFaixaNumeroProcesso
--		,pro.IdInstanciaTribunal
--		,pro.JusticaGratuita
--  from processo pro
--	,TermoTribunalProcesso ttp
--	,HistoricoStatusProcesso hsp
--where pro.Numero = ttp.Numero
--and pro.IdSolicitacaoCaptura = ttp.IdSolicitacaoCaptura
--and ttp.NomeParte like 'picpay%'
--and pro.id = hsp.IdProcesso
--and hsp.IdStatus = 24
--and not exists (select 1
--				 from processo pro1
--				 where pro1.IdSolicitacaoCaptura = 8764
--				 and pro1.Numero = pro.Numero)
--and pro.IdTribunalJustica = 5008
--and IdTecnologiaSite = 20
--=========================================================


--=========================================================
-- Inserir Novos Processo no Monitoramento do TJRJ - PJe
--=========================================================
--insert into Processo (IdSolicitacaoCaptura,Numero,IdTribunalJustica,IdStatus,Eletronico,IdTecnologiaSite,IdFaixaNumeroProcesso, IdInstanciaTribunal, justicagratuita)
--select 8765
--		,pro.Numero
--		,pro.IdTribunalJustica
--		,1
--		,pro.Eletronico
--		,5
--		,pro.IdFaixaNumeroProcesso
--		,pro.IdInstanciaTribunal
--		,pro.JusticaGratuita
--		--,ttp.CriadoEm
--  from processo pro
--	,TermoTribunalProcesso ttp
--		,HistoricoStatusProcesso hsp
--where pro.Numero = ttp.Numero
--and pro.IdSolicitacaoCaptura = ttp.IdSolicitacaoCaptura
--and ttp.NomeParte like 'picpay%'
--and pro.id = hsp.IdProcesso
--and hsp.IdStatus = 24
--and not exists (select 1
--				 from processo pro1
--				 where pro1.IdSolicitacaoCaptura = 8765
--				 and pro1.Numero = pro.Numero)
--and pro.IdTribunalJustica = 2
--and IdTecnologiaSite = 20
--=========================================================


--=========================================================
-- Inserir Novos Processo no Monitoramento do TJRJ - Próprio
--=========================================================
--insert into Processo (IdSolicitacaoCaptura,Numero,IdTribunalJustica,IdStatus,Eletronico,IdTecnologiaSite,IdFaixaNumeroProcesso, IdInstanciaTribunal, justicagratuita)
--select 8840
--		,pro.Numero
--		,pro.IdTribunalJustica
--		,1
--		,pro.Eletronico
--		,2
--		,pro.IdFaixaNumeroProcesso
--		,pro.IdInstanciaTribunal
--		,pro.JusticaGratuita
--		--,ttp.CriadoEm
--  from processo pro
--	,TermoTribunalProcesso ttp
--		,HistoricoStatusProcesso hsp
--where pro.Numero = ttp.Numero
--and pro.IdSolicitacaoCaptura = ttp.IdSolicitacaoCaptura
--and ttp.NomeParte like 'picpay%'
--and pro.id = hsp.IdProcesso
--and hsp.IdStatus = 24
--and not exists (select 1
--				 from processo pro1
--				 where pro1.IdSolicitacaoCaptura = 8840
--				 and pro1.Numero = pro.Numero)
--and pro.IdTribunalJustica = 2
--and IdTecnologiaSite = 2
--=========================================================


<----- ROTINA PARA PEGAR PROCESSO TJRJ PROPRIO MANUALMENTE --->

--select * from SolicitacaoCaptura where id = 8863
--"Captura Distribuição - TJRJ - Generico"

drop table #CapturaTJRJ

create table #CapturaTJRJ (numero varchar(30))

insert into #CapturaTJRJ (numero) values
('0031550-28.2021.8.19.0210')

insert into Processo (IdSolicitacaoCaptura,
						Numero,
						IdTribunalJustica,
						IdStatus,
						Eletronico,
						IdTecnologiaSite,
						IdInstanciaTribunal, 
						justicagratuita)
select 8863
		,a.numero
		,2
		,1
		,1
		,2
		,5302
		,0
	from #CapturaTJRJ a
	where not exists (select 1
						from processo pro
						where pro.IdSolicitacaoCaptura = 8863
						and pro.Numero = a.numero)

select *
  from processo
where IdSolicitacaoCaptura = 8863
and IdStatus not in (9,2)

select * from SolicitacaoCaptura where id = 8863

/*

update ProcessamentoCaptura
   set DataTermino = getdate()
where IdEquipamentoProcessamento = 39
and DataTermino is null


update EquipamentoProcessamento
   set Address = 'A463A1513F02'
where id = 39
--A463A1513F02

select * 
  from equipamentoprocessamentotribunal
where idequipamentoprocessamento = 39
and ativo = 1

select * 
  from equipamentoprocessamentotribunal
where idequipamentoprocessamento = 39
and idtribunal = 2

update equipamentoprocessamentotribunal set ativo = 1 where id = 3858

select *
  from solicitacaocaptura
where id = 8863
*/ 