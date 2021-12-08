
http://dashboard.omnijus.com.br:3000/d/2341bDBMzA/omnijus-operacional-producao?orgId=1&refresh=1h
login: carlos.silva
senha: Mudar@123


<----- Rotina diaria PicPay --------->

1-Realizar captura com robo da maquina 34 -- 172.13.0.15

2-Pegar email do dia anterior e conferir os processos 
  da planilha com o que capturamos utilizar a query abaixo

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
--and (select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 21) = 0
and pro.Numero in 
('5018802-22.2021.8.08.0035',
'5000909-27.2021.8.08.0032',
'0801943-27.2021.8.19.0083')
order by ttp.CriadoEm desc

3- Antes de executar o disponibilizarDistribuicao, verificar se 
   forum, vara e comarca estao com a nomeclatura certa com base
   no campo orgaojulgador, utilizar a query abaixo:

select pro.id as idprocesso
		,ttp.Numero
		,pro.IdStatus 
		,ttp.CriadoEm
		,pro.IdSolicitacaoCaptura
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 15) as DMB
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 5) as DPZ
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
and (select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 21) = 0
order by ttp.CriadoEm desc

/*
-- encontrar anteriores para correcao de forum vara e comarca

select top 100 *
  from Processo p
 where p.OrgaoJulgador = 'Cariacica - Comarca da Capital - 2º Juizado Especial Cível'
order by id desc


--3º Juizado Especial Cível da Comarca de Duque de Caxias

*/

/*
begin transaction

update Processo
set 
	vara = '25º JUIZADO ESPECIAL CÍVEL'
	,forum = 'PAVUNA'
	,comarca = 'CAPITAL'
where id = 1889200

commit transaction
*/

   SE NAO ESTIVER CORRETO OS CAMPOS FORUM VARA E COMARCA,
   PEGAR PELO ORGAO JULGADOR E DESMEMBRAR O CONTEUDO NOS 3 CAMPOS
   E FAZER O UPDTE NA BASE.

begin transaction

update Processo
set 
	vara = '17º Juizado Especial Cível'
	,forum = 'Bangu'
	,comarca = 'Capital'
where id in (1889138)

commit transaction

begin transaction

update Processo
set 
	vara = '12º JUIZADO ESPECIAL CÍVEL'
	,forum = 'Méier'
	,comarca = 'Capital'
where id in (1889138)

commit transaction

--14º Juizado Especial Cível da Regional de Jacarepaguá
--17º Juizado Especial Cível da Regional de Bangu
--12º Juizado Especial Cível da Regional do Méier
--20º Juizado Especial Cível da Regional da Ilha do Governador
--2º Juizado Especial Cível da Comarca de São Gonçalo


JUIZADO ESPECIAL CÍVEL, CRIMINAL E FAZENDA PÚBLICA	NOVA VENÉCIA	NOVA VENÉCIA	Nova Venécia - Juizado Especial Cível, Criminal e Fazenda Pública

1	1889147	0800577-81.2021.8.19.0202	2	15º Juizado Especial Cível	Madureira	Capital	   15º Juizado Especial Cível da Regional de Madureira
2	1889140	0801186-61.2021.8.19.0203	2	14º Juizado Especial Cível	Jacarepaguá	Capital	   14º Juizado Especial Cível da Regional de Jacarepaguá
3	1889138	0803011-37.2021.8.19.0204	2	17º Juizado Especial Cível	Bangu	    Capital	   17º Juizado Especial Cível da Regional de Bangu
4	1889141	0807631-14.2021.8.19.0036	2	1º JUIZADO ESPECIAL CÍVEL	NILÓPOLIS	NILÓPOLIS	1º Juizado Especial Cível da Comarca de Nilópolis
5	1889139	5007309-63.2021.8.08.0030	2	2º JUIZADO ESPECIAL CÍVEL	LINHARES	LINHARES	Linhares - 2º Juizado Especial Cível

<------------------------------------->

0- ANTES DE RODAR O DISPONIBILIZARDISTRIBUICAO VERIFICAR SE FORUM VARA E COMARCA ESTA CORRETOS!!

select pro.id		
	,pro.Numero
	,pro.IdStatus
	,pro.Vara
	,pro.Forum
	,pro.Comarca
	,pro.OrgaoJulgador
  from processo pro
where pro.numero in 
('0800577-81.2021.8.19.0202',
'0801186-61.2021.8.19.0203',
'5007309-63.2021.8.08.0030',
'0807631-14.2021.8.19.0036')


4- SE NAO ESTIVER CORRETO OS CAMPOS FORUM VARA E COMARCA,
   PEGAR PELO ORGAO JULGADOR E DESMEMBRAR O CONTEUDO NOS 3 CAMPOS
   E FAZER O UPDTE NA BASE.

begin transaction

update Processo
set 
	vara = '17º Juizado Especial Cível'
	,forum = 'Bangu'
	,comarca = 'Capital'
where id in (1889138)
commit transaction
--14º Juizado Especial Cível da Regional de Jacarepaguá
--17º Juizado Especial Cível da Regional de Bangu
JUIZADO ESPECIAL CÍVEL, CRIMINAL E FAZENDA PÚBLICA	NOVA VENÉCIA	NOVA VENÉCIA	Nova Venécia - Juizado Especial Cível, Criminal e Fazenda Pública

1	1889147	0800577-81.2021.8.19.0202	2	15º Juizado Especial Cível	Madureira	Capital	   15º Juizado Especial Cível da Regional de Madureira
2	1889140	0801186-61.2021.8.19.0203	2	14º Juizado Especial Cível	Jacarepaguá	Capital	   14º Juizado Especial Cível da Regional de Jacarepaguá
3	1889138	0803011-37.2021.8.19.0204	2	17º Juizado Especial Cível	Bangu	    Capital	   17º Juizado Especial Cível da Regional de Bangu
4	1889141	0807631-14.2021.8.19.0036	2	1º JUIZADO ESPECIAL CÍVEL	NILÓPOLIS	NILÓPOLIS	1º Juizado Especial Cível da Comarca de Nilópolis
5	1889139	5007309-63.2021.8.08.0030	2	2º JUIZADO ESPECIAL CÍVEL	LINHARES	LINHARES	Linhares - 2º Juizado Especial Cível

Cariacica - Comarca da Capital - 4º Juizado Especial Cível
Vila Velha - Comarca da Capital - 2º Juizado Especial Cível


begin transaction

update Processo
set 
	vara = '26º JUIZADO ESPECIAL CÍVEL'
	,forum = 'CAMPO GRANDE'
	,comarca = 'CAPITAL'
where id in (1889138)
commit transaction

26º Juizado Especial Cível da Regional de Campo Grande

1- CONFERIR PLANILHA VINDA DA OITO PARA CONFRONTAR CAPTURAS COM O QUE FOI CAPTURADO 
   PELA NOSSA FERRAMENTA E PELA FERRAMENTA EXTERNA
   USAR A QUERY ABAIXO PARA REALIZAR O CONFRONTO DE DADOS
 
select pro.id as idprocesso
		,ttp.Numero
		,pro.IdStatus as IdProcesso
		,pro.Distribuicao
		,ttp.CriadoEm
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 15) as Desmenbrado
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 5) as DisponibilizadoS3
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 21) as IntegradoOmnijus
		,pro.IdEquipamentoProcessamento
		,pro.PossuiDocumento
		,pro.IdSolicitacaoCaptura
		,pro.Area
  from TermoTribunalProcesso ttp
		,Processo pro
where ttp.Numero = pro.Numero
and ttp.IdSolicitacaoCaptura = pro.IdSolicitacaoCaptura
and ttp.NomeParte like 'PIC%'
and ttp.CriadoEm >= '2021-09-01 00:00:00'
--and (select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 21) = 0
and pro.Numero in 
('0800577-81.2021.8.19.0202',
'0801186-61.2021.8.19.0203',
'5007309-63.2021.8.08.0030',
'0807631-14.2021.8.19.0036')

order by ttp.CriadoEm desc


2- TIRAR OS ESPACOS EM BRANCO DO FORUM VARA E COMARCA

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


3- QUERY PARA VALIDAR SE FORUM VARA E COMARCA ESTAO CORRETOS

select pro.id		
	,pro.Numero
	,pro.IdStatus
	,pro.Vara
	,pro.Forum
	,pro.Comarca
	,pro.OrgaoJulgador
  from processo pro
where pro.numero in 
('0800577-81.2021.8.19.0202',
'0801186-61.2021.8.19.0203',
'5007309-63.2021.8.08.0030',
'0807631-14.2021.8.19.0036')


4- SE NAO ESTIVER CORRETO OS CAMPOS FORUM VARA E COMARCA,
   PEGAR PELO ORGAO JULGADOR E DESMEMBRAR O CONTEUDO NOS 3 CAMPOS
   E FAZER O UPDTE NA BASE.

begin transaction

update Processo
set 
	vara = '17º Juizado Especial Cível'
	,forum = 'Bangu'
	,comarca = 'Capital'
where id in (1889138)
commit transaction
--14º Juizado Especial Cível da Regional de Jacarepaguá
--17º Juizado Especial Cível da Regional de Bangu
--Cariacica - Comarca da Capital - 2º Juizado Especial Cível

1	1889147	0800577-81.2021.8.19.0202	2	15º Juizado Especial Cível	Madureira	Capital	   15º Juizado Especial Cível da Regional de Madureira
2	1889140	0801186-61.2021.8.19.0203	2	14º Juizado Especial Cível	Jacarepaguá	Capital	   14º Juizado Especial Cível da Regional de Jacarepaguá
3	1889138	0803011-37.2021.8.19.0204	2	17º Juizado Especial Cível	Bangu	    Capital	   17º Juizado Especial Cível da Regional de Bangu
4	1889141	0807631-14.2021.8.19.0036	2	1º JUIZADO ESPECIAL CÍVEL	NILÓPOLIS	NILÓPOLIS	1º Juizado Especial Cível da Comarca de Nilópolis
5	1889139	5007309-63.2021.8.08.0030	2	2º JUIZADO ESPECIAL CÍVEL	LINHARES	LINHARES	Linhares - 2º Juizado Especial Cível





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
('0045464-83.2021.8.19.0203'),
('0801153-65.2021.8.19.0205'),
('0807516-77.2021.8.19.0008'),
('0809207-50.2021.8.19.0001'),
('5006510-20.2021.8.08.0030'),
('5016462-66.2021.8.08.0048'),
('0007740-05.2021.8.19.0087'),
('0801391-72.2021.8.19.0209')
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

