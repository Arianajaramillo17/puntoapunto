import React, { useEffect, useState } from 'react'
import { useNavigate } from "react-router-dom";
import {
    Button,
    Divider,
    Label,
    Spinner,
    Table,
    TableBody,
    TableCell,
    TableCellLayout,
    TableHeader,
    TableHeaderCell,
    TableRow,
    Title2,
    Title3,
  } from "@fluentui/react-components";
  import { DocumentError24Regular } from "@fluentui/react-icons";
import { CommandBarV9 } from '../CommandBar/CommandBarV9';
import { StatusBase } from '../Status/StatusBase';

export const TableBaseV1 = (props:any) => {
    const navigate = useNavigate();
    const [loadingSpinner, setLoadingSpinner] = useState(true);
    const [cantRenderizado, setCantRenderizado] = useState(0);
    const [mensaje, setMensaje] = useState("");
  
    function validacion(data: []) {
      if (data?.length > 0) {
        setLoadingSpinner(false);
      }
    }
  
    useEffect(() => {
      validacion(props?.items);
      setCantRenderizado(cantRenderizado + 1);
    }, [props.items]);

    useEffect(() => {
      if (cantRenderizado >= 2) {
        if (props.items.length === 0) {
          setMensaje("SIN DATOS REGISTRADOS");
          setLoadingSpinner(false);
        } else {
          setMensaje("");
        }
      }
    }, [cantRenderizado]);
  
    return (
      <div style={{ width: "100%", maxHeight: props.height != null ? props.height : "100%" }}>
        <div style={{ margin: "5px 0px" }}>
  
      {  <CommandBarV9
            buttonLeft={props.buttonLeft}
            buttonRight={props.buttonRight}
          />}
        </div>
  
        {loadingSpinner ? (
          <div
            style={{
              display: "flex",
              justifyContent: "center",
              width: "1fr",
              alignItems: "center",
            }}
          >
            <br />
            <Spinner size="extra-small" label="Obteniendo Datos" />
          </div>
        ) : (
          <>
            <div
              style={{
                display: "flex",
                minWidth: "1fr",
                maxWidth: "1fr",
                overflowX: "scroll",
                margin: "0px 0px",
                paddingBottom: "20px",
                minHeight: "30px",
                maxHeight: "415px",
                overflowY: "scroll",
                borderTop: "0.5px solid #A1A8AB",
              }}
            >
              <Table size="small" arial-label="Default table">
                <TableHeader style={{ height: "auto" }}>
                  <TableRow>
                    {props.columns.map((column: any) => (
                      <>
                        <TableHeaderCell
                          key={column.key}
                          style={{
                            fontFamily: "inherit",
                            fontWeight: "600",
                            fontSize: ".8rem",
                            position: "sticky",
                            top: 0,
                            width: column.ancho,
                            zIndex: 1,
                            backgroundColor: "#fff",
                          }}
                        >
                          <>
                            {column.columns ? (
                              <>
                                <div style={{ display: "inline-block" }}>
                                  <div style={{ textAlign: "center" }}>
                                    <Label>{column.label}</Label>
                                    <div
                                      style={{ width: "100%", padding: "10px 0" }}
                                    >
                                      <Divider />
                                    </div>
                                  </div>
                                  <div
                                    style={{
                                      display: "flex",
                                      textAlign: "center",
                                    }}
                                  >
                                    {column.columns.map((column2: any) => (
                                      <div
                                        key={column2.key}
                                        style={{ width: column2.ancho }}
                                      >
                                        <Label>{column2.label}</Label>
                                      </div>
                                    ))}
                                  </div>
                                </div>
                              </>
                            ) : (
                              <> {column.label}</>
                            )}
                          </>
                        </TableHeaderCell>
                      </>
                    ))}
                  </TableRow>
                </TableHeader>
                <>
                  <>
                    <TableBody
                      style={{ maxHeight: "600px", overflowY: "scroll" }}
                    >
                      {props.items.map((item: any, i: number) => (
                        <TableRow key={i} style={{ height: "40px" }}>
                          {props.columns.map((column: any, index: number) => (
                            <TableCell
                              key={column.key}
                              style={{
                                height: "20px",
                                marginBottom: "50px",
                                width: column.ancho,
                              }}
                            >
                              {column?.status === true ? (
                              
                                <StatusBase estado={item[column.key]} />
                              ) : column.columns ? (
                                <>
                                  {column.columns.map((column2: any) => (
                                    <>
                                      <TableCell
                                        key={column2.key}
                                        style={{
                                          height: "20px",
                                          marginBottom: "50px",
                                          width: column2.ancho,
                                          textAlign: "center",
                                        }}
                                      >
                                        {item[column2.key]}
                                        {column2?.key === "render" && (
                                          <TableCellLayout
                                            style={{ textAlign: "center" }}
                                          >
                                            {column2.onRender &&
                                              column2.onRender(item, i)}
                                          </TableCellLayout>
                                        )}
                                      </TableCell>
                                    </>
                                  ))}
                                </>
                              ) : (
                                <div style={{ fontSize: "12px" }}>
                                  {item[column.key]}
                                  {(column.key === "render" || column.key === "render2") && (
                                    <TableCellLayout
                                      style={{ textAlign: "center" }}
                                    >
                                      {column.onRender && column.onRender(item)}
                                    </TableCellLayout>
                                  )}
                                </div>
                              )}
                            </TableCell>
                          ))}
                        </TableRow>
                      ))}
  
                      {props.footer ? (
                        <>
                          <TableRow
                            style={{
                              height: "40px",
                              background: "rgb(237, 235, 233)",
                              position: "sticky",
                              bottom: 0,
                              zIndex: 2,
                            }}
                          >
                            {props.footer.map((item: any) => (
                              <>
                                <TableCell
                                  colSpan={item?.colSpan ? item?.colSpan : 1}
                                  key={item.key}
                                  style={{
                                    height: "30px",
                                    marginBottom: "50px",
                                    width: "100px",
                                  }}
                                >
                                  {props.columns.map((colum: any) => (
                                    <>
                                      {item.key === colum.key ? (
                                        <>
                                          {" "}
                                          <Label style={{ fontWeight: "bold" }}>
                                            {item?.monto}
                                          </Label>
                                        </>
                                      ) : (
                                        <></>
                                      )}
                                    </>
                                  ))}
                                </TableCell>
                              </>
                            ))}
                          </TableRow>
                        </>
                      ) : (
                        <></>
                      )}
                    </TableBody>
                  </>
                </>
              </Table>
            </div>
            {mensaje !== "" && (
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  justifyContent: "flex-start",
                  width: "1fr",
                  height: "auto",
                  alignItems: "center",
                  color: "gray",
                }}
              >
                <>
                  <DocumentError24Regular
                    style={{ width: "50px", height: "50px" }}
                  />
                  <h4>{mensaje}</h4>
                  {props.btnString && (
                    <>
                      <div>¿Desea añadir {props.labelString}?</div> <br />
                      <Button
                        appearance="transparent"
                        shape="square"
                        style={{ border: '1.5px solid' }}
                        onClick={() => {
                          if (props.setOpen != null) {
                            props.setOpen(true);
                          } else if (props.navigate != null) {
                            navigate(props.navigate);
                          }
                        }
                        }
                      >
                        {props.btnString}
                      </Button>
                    </>
                  )}
                </>
              </div>
            )}
          </>
        )}
      </div>
    );
  };
  