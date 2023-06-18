'use client'

import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

type Props = {};

const Footer: React.FC<Props> = ({}) => {
  return (
    <View style={styles.container}>
      <Text>KROKETS</Text>
    </View>
  );
};

const styles = StyleSheet.create({
  "container": {
    height: 100,
    width: '100%',
    backgroundColor: 'blue',
  },
});

export default Footer;