import {
  Accordion,
  AccordionHeader,
  AccordionItem,
  AccordionPanel,
  AccordionToggleEventHandler,
  Body1,
  Caption1,
  Drawer,
  DrawerBody,
  DrawerHeader,
  DrawerHeaderNavigation,
  SelectTabData,
  SelectTabEvent,
  Tab,
  TabList,
  Toolbar,
  ToolbarButton,
  ToolbarGroup,
  Tooltip,
} from "@fluentui/react-components";
import  { useState } from "react";
import { useBoolean } from "@fluentui/react-hooks";
import "../../styles/SiderBarStyle.css"
import { useNavigate } from "react-router-dom";
import { ISiderBar } from "../../interfaces/ISiderBar/ISiderBar";
import { useIconsCatalogo } from "../../hooks/iconCatalog/useIconsCatalogo";

export const SiderBar = (props: ISiderBar) => {
  const navigate = useNavigate()
  const { Icon } = useIconsCatalogo(24);
  const [openItems, setOpenItems] = useState(["0"]);
  const [isOpenIcons, { setTrue: openIcons, setFalse: dismissIcons }] =
    useBoolean(true);

  const handleToggle: AccordionToggleEventHandler<string> = (event, data) => {
    if (event !== undefined) {
      setOpenItems(data.openItems);
    }
  };
  const onClickOpenSider = () =>
    isOpenIcons == true ? dismissIcons() : openIcons();

  const selectTab = (event: SelectTabEvent, data: SelectTabData) => {
    if (event !== undefined) {
      navigate(`${data.value}`);
    }
  };
  return (

    <Drawer
      type={"inline"}
      position="start"
      open={props.isOpen}
      style={
        isOpenIcons
          ? {
            width: `${props.width}px`,
            height: "calc(100vh - 48px)",
            transition: "width 0.5s ease",
          }
          : {
            width: "48px",
            height: "calc(100vh - 48px)",
            transition: "width 0.5s ease",
          }
      }
    >
      <div className="cuerpo">
        {isOpenIcons === true ? (
          <div className="siderbar-general">
            <DrawerHeader style={{ padding: "0px 25px" }}>
              <DrawerHeaderNavigation>
                <Toolbar style={{ justifyContent: "end" }}>
                  <ToolbarGroup>
                    <ToolbarButton
                      aria-label="Close panel"
                      appearance="subtle"
                      icon={Icon("FechasIzquierda")}
                      onClick={onClickOpenSider}
                    />
                  </ToolbarGroup>
                </Toolbar>
              </DrawerHeaderNavigation>
            </DrawerHeader>

            <DrawerBody
              style={{
                padding: "0px",
                border: "0px",
                backgroundColor: "rgb(243, 242, 241)",
              }}
            >
              <Accordion
                openItems={openItems}
                onToggle={handleToggle}
                multiple
              >
                <>
                  {props.linkNavGroups?.map((group:any) => (
                    <AccordionItem value={group.key} key={group.key}>
                      <AccordionHeader size={"large"} style={{padding:'0px'}} button={{style:{padding:'5px'}}}>
                        <Body1>
                          {group.name}
                        </Body1>
                      </AccordionHeader>
                      <AccordionPanel style={{margin:'5px'}}>
                        <TabList
                          key={group.key}
                          size="small"
                          vertical
                          appearance="subtle"
                          onTabSelect={selectTab}
                        >
                          {group.links?.map((link:any, index: number) => (
                            <Tab
                              key={index}
                              style={{
                                margin: "0px 0px",
                                padding: "7px 25px",
                              }}
                              icon={Icon(link.icon)}
                              value={link.url}
                            >
                              <Caption1>
                                {link.name}
                              </Caption1>
                            </Tab>
                          ))}
                        </TabList>
                      </AccordionPanel>
                    </AccordionItem>
                  ))}
                </>
              </Accordion>
            </DrawerBody>
          </div>
        ) : (

          <div className="siderbar-icons">
            <DrawerHeader style={{ padding: "0px 25px" }}>
              <DrawerHeaderNavigation>
                <Toolbar style={{ justifyContent: "end" }}>
                  <ToolbarGroup>
                    <ToolbarButton
                      aria-label="Close panel"
                      appearance="subtle"
                      icon={Icon("FechasDerecha")}
                      onClick={onClickOpenSider}
                    />
                  </ToolbarGroup>
                </Toolbar>
              </DrawerHeaderNavigation>
            </DrawerHeader>

            <DrawerBody
              style={{
                padding: "0px",
                backgroundColor: "rgb(243, 242, 241)",
              }}
            >
              <Accordion
                openItems={openItems}
                onToggle={handleToggle}
                multiple
              >
                {props.linkNavGroups?.map((group:any, index:number) => (
                  <AccordionItem value={index} key={index}>
                    <Tooltip
                      content={`${group.name}`}
                      positioning={"after"}
                      relationship="inaccessible"
                    >
                      <AccordionHeader
                        size={"large"}
                        button={{ style: { padding: "0px" } }}
                      ></AccordionHeader>
                    </Tooltip>

                    <AccordionPanel style={{ margin: "0px" }}>
                      <TabList
                        size="small"
                        vertical
                        appearance="subtle"
                        onTabSelect={selectTab}
                        style={{ width: "100%" }}
                      >
                        {group.links.map((link:any, index: number) => (
                          <Tooltip
                            key={index}
                            content={`${group.name}`}
                            positioning={"after"}
                            relationship="inaccessible"
                          >
                            <Tab
                              key={index}
                              style={{
                                margin: "0px 3px",
                                width: "100%",
                                padding: "10px 7px",
                              }}
                              icon={Icon(link.icon)}
                              value={link.url}
                            ></Tab>
                          </Tooltip>
                        ))}
                      </TabList>
                    </AccordionPanel>
                  </AccordionItem>
                ))}
              </Accordion>
            </DrawerBody>
          </div>
        )}
      </div>
    </Drawer>

  );
};
