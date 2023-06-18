'use client'

import { StyleSheet, Text, View } from "react-native";


export default function Home() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Today's nearest Asteroid</Text>
    </View>
  )
}

const styles = StyleSheet.create({
  "container": {
    backgroundColor: 'black',
  },
  "title": {
    color: 'white',
    fontSize: 32,
    fontWeight: 'bold',
    marginHorizontal: 'auto',
    paddingVertical: 15
  }
});
