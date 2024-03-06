export interface ISiderBar {
  isOpen: boolean;
  width: number;
  linkNavGroups?: TreeMenu[];
}
export interface TreeMenu {
  key: string;
  name?: string;
  links?: LinkMenu[] | [];
}

export interface LinkMenu {
  name: string;
  url: string;
  key?: string;
  links?: LinkMenu[] | [];
  icon?: string;
}
