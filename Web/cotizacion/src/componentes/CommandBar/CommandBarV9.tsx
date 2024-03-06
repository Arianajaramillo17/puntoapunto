import { Button, ButtonProps, CardFooter, Tooltip, makeStyles } from '@fluentui/react-components';
import React, { useEffect, useState } from 'react';
import { Add20Regular, ArrowClockwise20Regular, ArrowLeft20Filled, ArrowTrendingDown20Regular, ArrowTrendingDown24Regular, BookSearch24Filled, CalendarArrowCounterclockwise20Regular, CalendarArrowCounterclockwise24Regular, CalendarPlay20Regular, CalendarStar20Regular, ClipboardSettings20Regular, ClipboardTextEdit20Regular, DataUsageEdit20Regular, Delete20Regular, Dismiss20Regular, DocumentBulletList20Regular, DocumentTableArrowRight20Regular, DrawerArrowDownload20Regular, Edit20Regular, LocationArrow20Regular, MailArrowUp24Regular, Pen20Regular, Save20Regular, StarArrowRightStart20Regular } from '@fluentui/react-icons';
import { ICommandBarV9 } from '../../Interfaces/IComponents/CommandBar/ICommandBar';

const styles = makeStyles(
  {
    btn: {
      fontSize: "12px",
      paddingLeft: "0px"
    }
  }
);

export const CommandBarV9 = (props: ICommandBarV9) => {
  const style = styles();

  const IconStyle = (text: string) => {
    switch (text) {
      case "Nuevo":
        return (
          <Add20Regular />
        )
      case "Actualizar":
        return (
          <ArrowClockwise20Regular />
        )
    
      case "Derivar":
        return (
          <DocumentTableArrowRight20Regular />
        )
      case "Editar":
        return (
          <Edit20Regular />
        )
      case "Guardar":
        return (
          <Save20Regular />
        )
      case "Atrás":
        return (
          <ArrowLeft20Filled />
        )
      case "Excel":
        return (
          <DrawerArrowDownload20Regular />
        )
      case "Auditoria":
        return (
          <DrawerArrowDownload20Regular />
        )
      case "Nueva Reunión":
        return (
          <CalendarArrowCounterclockwise20Regular />
        )
      case "Descargar":
        return (
          <DrawerArrowDownload20Regular />
        )
      case "Realizar Monitoreo":
        return (
          <DocumentBulletList20Regular />
        )
      case "Iniciar Evaluación":
        return (
          <CalendarPlay20Regular />
        )
      case "Finalizar Evaluación":
        return (
          <CalendarStar20Regular />
        )
      case "Cancelar":
        return (
          <Dismiss20Regular />
        )
      case "Auditoría":
        return (
          <ClipboardTextEdit20Regular />
        )
      case "Enviar":
        return (
          <LocationArrow20Regular />
        )
      case "Liquidación":
        return (
          <ArrowTrendingDown20Regular />
        )
      case "Liquidaciones":
        return (
          <DataUsageEdit20Regular />
        )
      case "Configurar Monitoreo":
        return (
          <ClipboardSettings20Regular />
        )
      case "Subsanar":
        return (
          <Pen20Regular />
        )
      case "Eliminar":
        return (
          <Delete20Regular />
        )
      case "Notificar Registro":
        return (
          <MailArrowUp24Regular />
        )
      case "Análisis":
        return (
          <BookSearch24Filled />
        )




      default:
        break;
    }
  }

  return (
    <div style={{ display: 'flex', justifyContent: 'space-between' }}>
      <CardFooter style={{ display: 'flex', justifyContent: 'flex-start' }}>
        {props.buttonLeft?.map((item, i) => (
          <Button
            className={style.btn}
            key={i}
            onClick={item.onClick}
            appearance={item.appearance}
            icon={IconStyle(item.text)}
            disabled={item.disabled}
          >
            {item.text}
          </Button>
        ))}
      </CardFooter>

      <CardFooter style={{ display: (props.buttonRight != null) ? 'flex' : 'none', justifyContent: 'flex-end' }}>
        {props.buttonRight?.map((item, i) => (
          <Button
            className={style.btn}
            key={i} onClick={item.onClick} appearance={item.appearance}
            style={item.style}
            icon={IconStyle(item.text)} disabled={item.disabled} >{item.text}
          </Button>
        ))}
      </CardFooter>
    </div >
  );
};