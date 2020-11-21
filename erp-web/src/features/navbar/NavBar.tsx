import React, { useState } from 'react'
import { Button } from 'semantic-ui-react';
import Menu from 'semantic-ui-react/dist/commonjs/collections/Menu/Menu'

export const NavBar = () => {
    const [state, setstate] = useState('');

    return (
        <Menu fixed='top' color='blue' fluid inverted>
            <Menu.Item> 
                Conceptos
            </Menu.Item>
            <Menu.Item>
                Proveedores
            </Menu.Item>
            <Menu.Item>
                <Button>FUCK</Button>
            </Menu.Item>
        </Menu>
    )
}
