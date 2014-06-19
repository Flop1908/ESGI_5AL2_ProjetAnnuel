//
//  AnneManager.h
//  Anne&DocTique
//
//  Created by Kapi on 13/04/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreLocation/CoreLocation.h>

#import "AnneManagerDelegate.h"
#import "AnneCommunicatorDelegate.h"

@class AnneCommunicator;

@interface AnneManager : NSObject<AnneCommunicatorDelegate>
@property (strong, nonatomic) AnneCommunicator *communicator;
@property (weak, nonatomic) id<AnneManagerDelegate> delegate;

- (void)fetchGroupsAtCoordinate:(CLLocationCoordinate2D)coordinate;
@end