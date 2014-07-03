//
//  AnneCommunicator.h
//  Anne&DocTique
//
//  Created by Kapi on 01/03/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <Foundation/Foundation.h>

#import <CoreLocation/CoreLocation.h>

@protocol AnneCommunicatorDelegate;

@interface AnneCommunicator : NSObject
@property (weak, nonatomic) id<AnneCommunicatorDelegate> delegate;

- (void)searchCountryAtCoordinate;

- (NSString*)WhatSource:(NSString*)source withType:(NSString*)type andCount:(NSString*)count;
@end