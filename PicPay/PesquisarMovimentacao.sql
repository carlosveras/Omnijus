--===========================================================
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








