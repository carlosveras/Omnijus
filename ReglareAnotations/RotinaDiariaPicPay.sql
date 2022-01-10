
http://dashboard.omnijus.com.br:3000/d/2341bDBMzA/omnijus-operacional-producao?orgId=1&refresh=1h
login: carlos.silva
senha: Mudar@123

<-- observacao importante 18.12.2021 --->
processo abaixo:
1889317	PICPAY SERVICOS S.A	1	1	EMBARGANTE 0813598-39.2021.8.19.0004 --- > embargante
nao esta sendo disponibilizarDistribuicao pois o cliente é EMBARGANTE



ver com o renato essa rotina ---> GerarNumeroProcessoDistribuido


<---- QUERY PARA ENCONTRAR MAIOR IDSTATUS POR GRUPO DE REGISTROS DENTRO DE UMA DATA --->

 WITH ranked_hsp AS (
  SELECT m.*,   ROW_NUMBER() OVER (PARTITION BY IdProcesso ORDER BY IdStatus DESC) AS rn
  FROM HistoricoStatusProcesso AS m where cast(m.Data AS DATE) = '2021-12-20'
)
SELECT ranked_hsp.IdProcesso, 
       ranked_hsp.Data, 
	   ranked_hsp.IdStatus, 
	   sp.Descricao, 
	   p.Numero 
  FROM ranked_hsp
  join StatusProcesso sp on sp.Id = ranked_hsp.IdStatus
  join Processo p on p.id = ranked_hsp.IdProcesso
 WHERE rn = 1; --<< escolher o rank 1,2,3 etc

<---- Maquinas Ativas para captura e processamento PICPAY ---->

33 --172.13.0.14 

34 --172.13.0.15 

35 --172.13.0.16 

<----- Rotina diaria PicPay --------->

1-Realizar captura com robo da maquina 34 -- 172.13.0.15

2-Pegar email do dia anterior, este e-mail chega em torno das 8:00hrs
  email -- PicPay - Processos Distribuídos
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

---=========================================
-- ver esta rotina com o Renato. Atencao !!!
-- se retornar processos com status 4
--==========================================

--update processo
--   set IdStatus = 1 , Inconsistencia = null, PossuiDocumento = 0, IdEquipamentoProcessamento = null
--where IdStatus = 4
--and IdSolicitacaoCaptura in (8764,8866,8765,8867,8868,8840,8869,8870)

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
-- Notificação: OMNIJUS - Processos Ativos PicPay
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

0803532-67.2021.8.19.0208

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
--where p.IdSolicitacaoCaptura in  (8764, 8765,8840, 8866, 8867,8868 ,8869, 8870)
order by pm.AlteradoEm desc
--group by pm.Descricao, pm.Numero


/*





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

Na maquina que rodar esse procedimento, deve-se 
rodar tambem o DesmembrarArquivo e TransferirProcesso,
sempre lembrando que os projetos devem estar apontando
para o ambiente de producao.

--select * from SolicitacaoCaptura where id = 8863

Colocar a frase abaixo na propriedade do projeto
Capturar distribuicao para capturar o TJRJ Proprio
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

---- QUERY PARA MONTAR BASE ORGAOJULGADOR PARA PESQUISAR

select distinct 
       upper(p.vara) as VARA,  
       upper(p.comarca) AS COMARCA,  
	   upper(p.forum) AS FORUM,  
	   upper(p1.OrgaoJulgador) AS ORGAOJULGADOR
  from Processo p
  join Processo p1 on p1.id = p.Id 
 where p.OrgaoJulgador is not null


---- query para pesquisar processos
---- com base e-mail Notificação: OMNIJUS - Relatório de Movimentações PicPay
---para testar tempo de execucao da query

select pro.id 
      ,pro.Numero
      ,pro.Forum
	  ,pro.Vara
	  ,pro.OrgaoJulgador
	  ,hsp.IdStatus
	  ,sp.Descricao
	  ,hsp.Data CriadoEm
  from Processo pro
  join HistoricoStatusProcesso hsp on hsp.IdProcesso = pro.id 
  join StatusProcesso sp on sp.Id = hsp.IdStatus
and hsp.IdStatus = 23
--and cast(hsp.Data AS DATE) = '2021-12-17'
and year(hsp.Data) = 2021
and month(hsp.Data) = 12
and day(hsp.Data) = 17
order by hsp.Id desc

--------- QUERY PARA PLANILHA DIARIA - COMPARATIVO OITO x REGLARE
drop table #CapturaOmnijus

create table #CapturaOmnijus (numero varchar(30), CapturadoEm DATETIME)
insert into #CapturaOmnijus (CapturadoEm, numero) values
('2021-12-28 08:54:12','0803532-67.2021.8.19.0208')


select p.Numero, 
       format(co.CapturadoEm, ('dd-MM-yyyy')) As CaptOito, 
	   tj.Sigla,
       format(hsp.Data, ('dd-MM-yyyy')) As CaptReglare,
	   DATEDIFF(DAY, HSP.Data, co.CapturadoEm) as diasDif
  from #CapturaOmnijus co
 left join Processo p on p.Numero = co.numero
 join HistoricoStatusProcesso hsp on hsp.IdProcesso = p.Id
 join TribunalJustica tj on tj.Id = p.IdTribunalJustica
where hsp.IdStatus = 2
and p.vara is not null

--------- QUERY PARA PLANILHA DIARIA - CAPTURADOS REGLARE

select p.Numero, 
       format(hsp.Data, ('dd-MM-yyyy HH:mm:ss')) As CaptReglare,
	   tj.Sigla
  from HistoricoStatusProcesso hsp
 join Processo p on p.Id = hsp.IdProcesso
 join TribunalJustica tj on tj.Id = p.IdTribunalJustica
where hsp.IdStatus = 2
and cast(hsp.Data AS DATE) = '2022-01-05' --<-- ATENTE PARA A DATA
and p.vara is not null


-------- QUERY PARA A PLANILHA DIARIA - MOVIMENTOS REGLARE

select p.Numero
	  ,format(hsp.Data, ('dd-MM-yyyy HH:mm:ss')) As CaptReglare
	  ,tj.Sigla
	  ,p.Vara
  from HistoricoStatusProcesso hsp
  join Processo p on p.id = hsp.IdProcesso 
  join TribunalJustica tj on tj.Id = p.IdTribunalJustica
 where hsp.IdStatus = 23 --<-- Capturado -- 21.Distribuido -- 23.Movimentado
   and cast(hsp.Data AS DATE) = '2022-01-04' --<-- ATENTE PARA A DATA
 order by hsp.Id desc


<---- QUERY PARA RELATORIO WARLEY DIARIO --  CAPTURADOS REGLARE  -->

select 
       p.Numero
	  ,hsp.Data 
	  ,tj.Sigla
	  ,p.Vara
  from HistoricoStatusProcesso hsp
  join Processo p on p.id = hsp.IdProcesso 
  join TribunalJustica tj on tj.Id = p.IdTribunalJustica
 where hsp.IdStatus = 2 --<-- Capturado -- 21.Distribuido -- 23.Movimentado
--and cast(hsp.Data AS DATE) = '2021-12-17'
and year(hsp.Data) = 2021
and month(hsp.Data) = 12
and day(hsp.Data) = 20
order by hsp.Id desc


<------ QUERY OVER PARTITION

create table #MovOmnijus (numero varchar(30), idprocesso int)
insert into #MovOmnijus (numero) values
('0007208-56.2021.8.19.0208'),
('0007951-84.2021.8.19.0202'),
('0010826-83.2021.8.19.0054'),
('0804208-27.2021.8.19.0204'),
('0802487-83.2021.8.19.0028'),
('0805021-80.2021.8.19.0066'),
('0801099-46.2021.8.19.0061'),
('0018620-96.2021.8.19.0203'),
('0044557-72.2021.8.19.0021'),
('0803095-65.2021.8.19.0001'),
('0805122-12.2021.8.19.0004'),
('0803500-17.2021.8.19.0029'),
('0810247-67.2021.8.19.0001'),
('5000597-32.2021.8.08.0006'),
('5003936-67.2021.8.08.0048'),
('5004125-74.2021.8.08.0006'),
('5012987-16.2021.8.08.0012'),
('5015543-77.2021.8.08.0048')

UPDATE mov
   SET mov.idprocesso = p.Id 
  FROM #MovOmnijus mov
  JOIN Processo p ON mov.numero = p.Numero
  
WITH ranked_hsp AS (
  SELECT h.*,  ROW_NUMBER() OVER (PARTITION BY h.IdProcesso ORDER BY h.Data DESC) AS rn
  FROM HistoricoStatusProcesso h 
  JOIN #MovOmnijus mov on mov.idprocesso = h.IdProcesso)

SELECT ranked_hsp.IdProcesso, 
       ranked_hsp.Data, 
	   ranked_hsp.IdStatus, 
	   sp.Descricao, 
	   p.Numero 
  FROM ranked_hsp
  JOIN StatusProcesso sp on sp.Id = ranked_hsp.IdStatus
  JOIN Processo p on p.id = ranked_hsp.IdProcesso
 WHERE rn = 1; --<< escolher o rank 1,2,3 etc









