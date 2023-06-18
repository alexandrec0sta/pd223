'use client'

import Link from 'next/link';
import React from 'react';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';

type Props = {};

const Header: React.FC<Props> = ({}) => {
  return(
  <View style={styles.container}>
    <View style={styles.navContainer}>
      <TouchableOpacity style={{height: '100%'}}>
        <View style={styles.navItem}>
          <Link href="/">
          <Text style={[styles.text, styles.logo]}>PD Asteroids</Text>
          </Link>
        </View>
      </TouchableOpacity>
      <TouchableOpacity style={{height: '100%'}}>
        <View style={styles.navItem}>
          <Link href="/">
            <Text style={styles.text}>Home</Text>
          </Link>
        </View>
      </TouchableOpacity>
      <TouchableOpacity style={{height: '100%'}}>
        <View style={styles.navItem}>
          <Link href="/search">
            <Text style={styles.text}>Search</Text>
          </Link>
        </View>
      </TouchableOpacity>
      <TouchableOpacity style={{height: '100%'}}>
        <View style={styles.navItem}>
          <Link href="/collection">
            <Text style={styles.text}>Collection</Text>
          </Link>
        </View>
      </TouchableOpacity>
    </View>
  </View>
  );
};

const styles = StyleSheet.create({
  "container": {
    width: '100%',
    height: '50px',
    backgroundColor: 'black',
    border: 'solid #343d46 1px',
    borderTopColor: 'black',
  },
  "text": {
    color: 'white',
  },
  "logo": {
    textTransform: 'uppercase',
    fontWeight: 'bold',
    fontSize: 18
  },
  "navContainer": {
      width: '100%',
      height: '100%',
      display: 'flex',
      flexDirection: 'row',
      justifyContent: 'flex-start',
      alignItems: 'center',
  },
  "navItem": {
    height: '100%',
    display: 'flex',
    flexDirection: 'row',
    justifyContent: 'flex-start',
    alignItems: 'center',
    paddingHorizontal: 10,
  }
});

export default Header;