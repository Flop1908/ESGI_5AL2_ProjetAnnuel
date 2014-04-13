//
//  AnneCommunicator.h
//  Anne&DocTique
//
//  Created by Kapi on 13/04/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <Foundation/Foundation.h>

#import <CoreLocation/CoreLocation.h>

@protocol AnneCommunicatorDelegate;

@interface AnneCommunicator : NSObject
@property (weak, nonatomic) id<AnneCommunicatorDelegate> delegate;

- (void)searchGroupsAtCoordinate:(CLLocationCoordinate2D)coordinate;
@end