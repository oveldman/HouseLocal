#!/bin/bash
if ifconfig | grep -q "tun\|tap"; then
    echo "Connected to VPN"
else
    echo "Not connected to VPN"
fi
