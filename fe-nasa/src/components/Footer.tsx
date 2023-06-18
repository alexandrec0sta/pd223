'use client'

import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

type Props = {};

const Footer: React.FC<Props> = ({}) => {
  return (
    <View style={styles.container}>
      <Text style={styles.text}>Alexandre Costa, Diogo Vilhena, Diogo Nunes</Text>
      <Text style={styles.text}>MEI ISEC - Plataformas de Desenvolvimento 2023</Text>
    </View>
  );
};

const styles = StyleSheet.create({
  "container": {
    height: 100,
    width: '100%',
    backgroundColor: 'black',
    border: 'solid #343d46 1px',
    borderBottomColor: 'black',

    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'flex-end',
    alignItems: 'center',
    paddingBottom: 10
  },
  "text": {
    color: 'white',
  }
});

export default Footer;