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

