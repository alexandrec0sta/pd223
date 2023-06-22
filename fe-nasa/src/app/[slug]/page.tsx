'use client'

import { usePathname, } from 'next/navigation';
import React from 'react';
import { Text } from 'react-native';

type Props = {};

const ItemInfoPage: React.FC<Props> = ({}) => {
  const pathName = usePathname();
  const slugName = pathName.slice(1);
  return(
    <>
      <Text style={{color: 'white'}}>{slugName}</Text>
    </>
  );
};

export default ItemInfoPage