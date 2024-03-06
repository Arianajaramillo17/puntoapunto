import { Slot } from "@fluentui/react-components";

export interface ICommandBarV9 {
    buttonRight: ObjectCommandBar[],
    buttonLeft: ObjectCommandBar[],
}
export interface ObjectCommandBar {
    text: string
    style?: {}
    onClick: () => void
    icon?: Slot<'span'>,
    appearance?: 'secondary' | 'primary' | 'outline' | 'subtle' | 'transparent';
    disabled?: true | false;
    button?: true | false;
    relationShip?: 'label' | 'description' | 'inaccessible' | "";
    content?: string,
    hidden?: boolean | undefined;
}

