'use client'

import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

type Props = {};

const Header: React.FC<Props> = ({}) => {
  return(
  <View style={styles.container}>
    <Text>Juan</Text>
  </View>
  );
};

const styles = StyleSheet.create({
  "container": {
    width: '100%',
    height: '50px',
    backgroundColor: 'red'    
  },
});

export default Header;